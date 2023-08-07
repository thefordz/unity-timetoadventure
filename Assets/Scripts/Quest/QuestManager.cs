using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : Singleton<QuestManager>
{
    [Header("Character")] 
    [SerializeField] private Character _character;
    
    [Header("Quests")] 
    [SerializeField] private Quest[] questAvailable;
    
    [Header("Inspecter Quests")]
    [SerializeField] private InspectorQuestDescription _inspectorQuestPrefab;
    [SerializeField] private Transform inspecterQuestContainer;

    [Header("Character Quests")] 
    [SerializeField] private CharacterQuestDescription _characterQuestPrefab;
    [SerializeField] private Transform CharacterQuestContainer;

    [Header("Panel Quest Complete")] 
    [SerializeField] private GameObject PanelQuestComplete;
    [SerializeField] private TextMeshProUGUI questName;
    [SerializeField] private TextMeshProUGUI questRewardGold;
    [SerializeField] private TextMeshProUGUI questRewardItemAmount;
    [SerializeField] private Image questRewardItemIcon;
    
    public Quest QuestForClaim { get; private set; }
    void Start()
    {
        CarryQuestInspector();
    }

    private void Update()
    {
    }

    private void CarryQuestInspector()
    {
        for (int i = 0; i < questAvailable.Length; i++)
        {
            InspectorQuestDescription newQuest = Instantiate(_inspectorQuestPrefab, inspecterQuestContainer);
            newQuest.ConfigQuestUI(questAvailable[i]);
        }
    }

    private void AddQuestForConmplete(Quest questForComplete)
    {
        CharacterQuestDescription newQuest = Instantiate(_characterQuestPrefab, CharacterQuestContainer);
        newQuest.ConfigQuestUI(questForComplete);
    }

    public void AddQuest(Quest questForComplete)
    {
        AddQuestForConmplete(questForComplete);
    }

    public void ClaimReward()
    {
        if (QuestForClaim == null)
        {
            return;
        }
        
        MoneyManager.Instance.AddMoney(QuestForClaim.RewardGold);
        Inventory.Instance.AddItem(QuestForClaim.RewardItem.Item, QuestForClaim.RewardItem.Amount);
        PanelQuestComplete.SetActive(false);
        QuestForClaim = null;
    }
    public void AddProgress(string questID, int Amount)
    {
        Quest questForUpdate = QuestExit(questID);
        questForUpdate.WaitProgress(Amount);
    }

    private Quest QuestExit(string questID)
    {
        for (int i = 0; i < questAvailable.Length; i++)
        {
            if (questAvailable[i].ID == questID)
            {
                return questAvailable[i];
            }
        }

        return null;
    }

    private void ShowQuestComplete(Quest questComplete)
    {
        PanelQuestComplete.SetActive(true);
        questName.text = questComplete.Name;
        questRewardGold.text = questComplete.RewardGold.ToString();
        questRewardItemAmount.text = questComplete.RewardItem.Amount.ToString();
        questRewardItemIcon.sprite = questComplete.RewardItem.Item.Icon;
    }
    void QuestCompleteResponse(Quest questComplete)
    {
        QuestForClaim = QuestExit(questComplete.ID);
        if (QuestForClaim != null)
        {
            ShowQuestComplete(QuestForClaim);
        }
    }
    private void OnEnable()
    {
        Quest.EventQuestComplete += QuestCompleteResponse;
    }

    private void OnDisable()
    {
        Quest.EventQuestComplete -= QuestCompleteResponse;
    }
}
