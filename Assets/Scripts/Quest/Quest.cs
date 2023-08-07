using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class Quest : ScriptableObject
{
    public static Action<Quest> EventQuestComplete;
    
    [Header("Info")] 
    public string Name;
    public string ID;
    public int AmountObj;

    [Header("Description")] 
    [TextArea] public string Description;

    [Header("Reward")] 
    public int RewardGold;
    public QuestRewardItem RewardItem;

    [HideInInspector] public int CurrentAmount;
    [HideInInspector] public bool QuestCompleteCheck;

    public void WaitProgress(int Amount)
    {
        CurrentAmount += Amount;
        VerifyQuestComplete();
    }

    private void VerifyQuestComplete()
    {
        if (CurrentAmount >= AmountObj)
        {
            CurrentAmount = AmountObj;
            QuestComplete();
        }
    }

    private void QuestComplete()
    {
        if (QuestCompleteCheck)
        {
            return;
        }
        QuestCompleteCheck = true;
        EventQuestComplete?.Invoke(this);
    }

    private void OnEnable()
    {
        QuestCompleteCheck = false;
        CurrentAmount = 0;
    }
}


[Serializable]
public class QuestRewardItem
{
    public InventoryItem Item;
    public int Amount;
}