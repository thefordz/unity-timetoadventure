using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemByAdd : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private InventoryItem inventoryItemRef;
    [SerializeField] private int amountToAdd;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.Instance.AddItem(inventoryItemRef, amountToAdd);
            Destroy(gameObject);
        }
    }
}

