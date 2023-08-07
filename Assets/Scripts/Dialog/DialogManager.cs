using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : Singleton<DialogManager>
{
    [SerializeField] private GameObject panelDialog;
    [SerializeField] private Image npcIcon;
    [SerializeField] private TextMeshProUGUI npcName;
    [SerializeField] private TextMeshProUGUI npxConversation;
    public NPCInteraction NPCAvailable { get; set; }

    private Queue<string> dialogSequence;
    private bool dialogAnim;
    private bool closeShow;
    public PlayerController playerController;


    private void Start()
    {
        playerController = new PlayerController();
        dialogSequence = new Queue<string>();
    }
    
    private void Update()
    {
        if (NPCAvailable == null)
        {
           return; 
        }

        
        if (Input.GetKeyDown(KeyCode.E))
        {
            ConfigPanel(NPCAvailable.Dialog);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
        
            if (closeShow)
            {
                OpenClosePanelDialog(false);
                closeShow = false;
                return;
            }
        
            if (NPCAvailable.Dialog.ContainerInteractionExtra)
            {
                UIManager.Instance.OpenPanelInteraction(NPCAvailable.Dialog.InteractionExtra);
                OpenClosePanelDialog(false);
                return;
            }
            
            if (dialogAnim)
            {
                ContinueDialog();
            }
        }
    }

    public void OpenClosePanelDialog(bool condition)
    {
        panelDialog.SetActive(condition);
    }

    private void ConfigPanel(NPCDialog npcDialog)
    {
        OpenClosePanelDialog(true);
        CarryDialogSequence(npcDialog);
        
        npcIcon.sprite = npcDialog.Icon;
        npcName.text = $"{npcDialog.Name} : ";
        ShowTextConAnim(npcDialog.Greeting);
    }

    private void CarryDialogSequence(NPCDialog npcDialog)
    {
        if (npcDialog.Conversation ==null || npcDialog.Conversation.Length <= 0)
        {
            return;
        }


        for (int i = 0; i < npcDialog.Conversation.Length; i++)
        {
            dialogSequence.Enqueue(npcDialog.Conversation[i].Prayer);
        }
    }

    private void ContinueDialog()
    {
        if (NPCAvailable == null)
        {
            return;
        }

        if (closeShow)
        {
            return;
        }

        if (dialogSequence.Count == 0)
        {
            string close = NPCAvailable.Dialog.Farewell;
            ShowTextConAnim(close);
            closeShow = true;
            return;
        }
        
        string nextDialog = dialogSequence.Dequeue();
        ShowTextConAnim(nextDialog);
    }

    private IEnumerator AnimateText(string prayer)
    {
        dialogAnim = false;
        npxConversation.text = "";
        char[] letters = prayer.ToCharArray();
        for (int i = 0; i<letters.Length; i++)
        {
            npxConversation.text += letters[i];
            yield return new WaitForSeconds(0.03f);
        }

        dialogAnim = true;
    }


    private void ShowTextConAnim(string prayer)
    {
        StartCoroutine(AnimateText(prayer));
    }
    
    


    void OnClick()
    {
        Debug.Log("Click");
    }
    
}
