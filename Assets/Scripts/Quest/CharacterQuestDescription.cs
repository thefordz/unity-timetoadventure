using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterQuestDescription : QuestDescription
{
    [SerializeField] private TextMeshProUGUI taskObj;
    [SerializeField] private TextMeshProUGUI rewardGold;

    [Header("Item")]
    [SerializeField] private Image rewardItemIcon;
    [SerializeField] private TextMeshProUGUI rewardItemAmount;

    private void Update()
    {
        if (QuestForComplete.QuestCompleteCheck)
        {
            return;
        }
        
        taskObj.text = $"{QuestForComplete.CurrentAmount} / {QuestForComplete.AmountObj}";
    }

    public override void ConfigQuestUI(Quest quest)
    {
        base.ConfigQuestUI(quest);
        rewardGold.text = quest.RewardGold.ToString();
        taskObj.text = $"{quest.CurrentAmount} / {quest.AmountObj}";

        rewardItemIcon.sprite = quest.RewardItem.Item.Icon;
        rewardItemAmount.text = quest.RewardItem.Amount.ToString();

    }

    private void QuestCompleteResponse(Quest questComplete)
    {
        if (questComplete.ID == QuestForComplete.ID)
        {
            taskObj.text = $"{QuestForComplete.CurrentAmount} / {QuestForComplete.AmountObj}";
            gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        if (QuestForComplete.QuestCompleteCheck)
        {
            gameObject.SetActive(false);
        }
        Quest.EventQuestComplete += QuestCompleteResponse;
    }

    private void OnDisable()
    {
        Quest.EventQuestComplete -= QuestCompleteResponse;
    }
}
