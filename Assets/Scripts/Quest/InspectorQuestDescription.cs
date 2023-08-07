using TMPro;
using UnityEngine;

public class InspectorQuestDescription : QuestDescription
{
    [SerializeField] private TextMeshProUGUI questReward;
    public override void ConfigQuestUI(Quest quest)
    {
        base.ConfigQuestUI(quest);
        QuestForComplete = quest;
        questReward.text = $"-{quest.RewardGold} gold" +
                           $"\n-{quest.RewardItem.Item.name} x {quest.RewardItem.Amount}";
    }

    public void AcceptQuest()
    {
        if (QuestForComplete == null)
        {
            return;
        }
        
        QuestManager.Instance.AddQuest(QuestForComplete);
        gameObject.SetActive(false);
    }
}
