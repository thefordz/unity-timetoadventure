using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestDescription : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questName;
    [SerializeField] private TextMeshProUGUI questDesc;

    public Quest QuestForComplete { get; set; }
    
    public virtual void ConfigQuestUI(Quest quest)
    {
        QuestForComplete = quest;
        questName.text = quest.Name;
        questDesc.text = quest.Description;
    }
}
