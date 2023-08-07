using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Paneles")] 
    [SerializeField] private GameObject panelInventory;
    [SerializeField] private GameObject panelInspectorQuests;
    [SerializeField] private GameObject panelCharacterQuests;
    [SerializeField] private GameObject panelCooking;
    [SerializeField] private GameObject panelCookingInfo;
    [SerializeField] private GameObject panelInfo;
    [SerializeField] private GameObject panelShop;
    [SerializeField] private GameObject panelSetting;
    
    [Header("Bar")]
    [SerializeField] private Image playerHealth;

    [Header("Text")] 
    [SerializeField] private TextMeshProUGUI money;

    private float currentHealth;
    private float maxHealth;
    private void Update()
    {
        //UpdateUIChareacter();
        OpenClosePanelInfo();
        UpdateUICharecter();
        //OpenClosePanelShop();
    }

    private void UpdateUICharecter()
    {
        
        playerHealth.fillAmount = Mathf.Lerp(playerHealth.fillAmount, currentHealth / maxHealth, 10f * Time.deltaTime);
        money.text = MoneyManager.Instance.MoneyTotel.ToString();
    }
    
    public void UpdateHealthCharacter(float pCurrentHealth, float pMaxHealth)
    {
        currentHealth = pCurrentHealth;
        maxHealth = pMaxHealth;
    }

    #region  Paneles

    public void OpenClosePanelInfo()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            panelInfo.SetActive(!panelInfo.activeSelf);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            panelInfo.SetActive(false);
        }
        
    }
    

    

    
    public void OpenClosePanelShop()
    {
        panelShop.SetActive(!panelShop.activeSelf);
    }

    public void ClosePanelShop()
    {
        panelShop.SetActive(false);
    }

    public void OpenClosePanelSetting()
    {
        panelSetting.SetActive(!panelSetting.activeSelf);
    }
    
    public void OpenClosePanelCooking()
    {
        OpenColsePanelCookingInfo(false);
        panelCooking.SetActive(!panelCooking.activeSelf);
    }

    public void OpenColsePanelCookingInfo(bool condition)
    {
        panelCookingInfo.SetActive(condition);
    }
    

    public void OpenClosePanelInspecterQuest()
    {
        panelInspectorQuests.SetActive(!panelInspectorQuests.activeSelf);
    }

    public void OpenPanelInteraction(InteractionExtraNPC typeInteraction)
    {
        switch (typeInteraction)
        {
            case InteractionExtraNPC.Quest :
                OpenClosePanelInspecterQuest();
                break;
            case InteractionExtraNPC.Trade :
                OpenClosePanelShop();
                break;
            case InteractionExtraNPC.Crafing :
                OpenClosePanelCooking();
                break;
        }
    }
    public void OpenClosePanelInventory()
    {
        panelInventory.SetActive(!panelInventory.activeSelf);
    }
    
    public void OpenClosePanelCharacterQuest()
    {
        panelCharacterQuests.SetActive(!panelCharacterQuests.activeSelf);
    }

    #endregion
}
