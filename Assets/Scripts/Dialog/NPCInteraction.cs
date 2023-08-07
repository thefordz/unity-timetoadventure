using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private GameObject npcButtonInteraction;
    [SerializeField] private NPCDialog npcDialog;
    [SerializeField] private GameObject panel;

    public NPCDialog Dialog => npcDialog;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            panel.SetActive(true);
            //DialogManager.Instance.NPCAvailable = this;
            //npcButtonInteraction.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(false);
            //DialogManager.Instance.NPCAvailable = null;
            //npcButtonInteraction.SetActive(false);
        }
    }
}
