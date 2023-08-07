using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [Header("Item")] 
    [SerializeField] private InventoryItem[] itemInventory;
    [SerializeField] private Character character;
    [SerializeField] private int numberSlots;
    
    public Character Character => character;
    public int NumberSLots => numberSlots;
    public InventoryItem[] ItemInventory => itemInventory;

    

    private void Start()
    {
        itemInventory = new InventoryItem[numberSlots];
    }

    public void AddItem(InventoryItem itemByAdd, int amounted)
    {
        if (itemByAdd == null)
        {
            return;
        }

        
        List<int> indexes = VerifyStock(itemByAdd.ID);
        if (itemByAdd.IsCumulative)
        {
            if (indexes.Count > 0)
            {
                for (int i = 0; i < indexes.Count; i++)
                {
                    if (itemInventory[indexes[i]].Amount < itemByAdd.CumulativeMax)
                    {
                        itemInventory[indexes[i]].Amount += amounted;
                        if (itemInventory[indexes[i]].Amount > itemByAdd.CumulativeMax)
                        {
                            int verifystock = itemInventory[indexes[i]].Amount - itemByAdd.CumulativeMax;
                            itemInventory[indexes[i]].Amount = itemByAdd.CumulativeMax;
                            AddItem(itemByAdd, verifystock);
                        }
                        
                        InventoryUI.Instance.DrawItemInInventory(itemByAdd, itemInventory[indexes[i]].Amount, indexes[i]);
                        return;
                    }
                }
            }
        }

        if (amounted <= 0)
        {
            return;
        }

        if (amounted > itemByAdd.CumulativeMax)
        {
            AddItemInSlotAvailable(itemByAdd, itemByAdd.CumulativeMax);
            amounted -= itemByAdd.CumulativeMax;
            AddItem(itemByAdd, amounted);
        }
        else
        {
            AddItemInSlotAvailable(itemByAdd, amounted);
        }
    }

    private List<int> VerifyStock(string itemID)
    {
        List<int> indexOfItem = new List<int>();
        for (int i = 0; i < itemInventory.Length; i++)
        {
            if (itemInventory[i] != null)
            {
                if (itemInventory[i].ID == itemID)
                {
                    indexOfItem.Add(i);
                }
            }
        }

        return indexOfItem;
    }

    public int GetAmountItem(string itemID)
    {
        List<int> indexes = VerifyStock(itemID);
        int AmountTotal = 0;
        foreach (int index  in indexes)
        {
            if (itemInventory[index].ID == itemID)
            {
                AmountTotal += itemInventory[index].Amount;
            }
        }

        return AmountTotal;
    }

    public void ConsumeItem(string itemID)
    {
        List<int> indexes = VerifyStock(itemID);
        if (indexes.Count > 0)
        {
            DeleteItem(indexes[indexes.Count-1]);
        }
    }
    private void AddItemInSlotAvailable(InventoryItem item, int amounted)
    {
        for (int i = 0; i < itemInventory.Length; i++)
        {
            if (itemInventory[i] == null)
            {
                itemInventory[i] = item.CopyItem();
                itemInventory[i].Amount = amounted;
                InventoryUI.Instance.DrawItemInInventory(item, amounted, i);
                return;
            }
        }
    }

    private void DeleteItem(int index)
    {
        ItemInventory[index].Amount--;
        if (itemInventory[index].Amount <= 0)
        {
            itemInventory[index].Amount = 0;
            itemInventory[index] = null;
            InventoryUI.Instance.DrawItemInInventory(null, 0,index);
        }
        else
        {
            InventoryUI.Instance.DrawItemInInventory(itemInventory[index], itemInventory[index].Amount, index);
        }
    }

    public void MoverItem(int indexInitial, int indexFinal)
    {
        if (itemInventory[indexInitial] == null || itemInventory[indexFinal]!=null)
        {
            return;
        }
        
        //copy item in slot final
        InventoryItem itemForMove = itemInventory[indexInitial].CopyItem();
        itemInventory[indexFinal] = itemForMove;
        InventoryUI.Instance.DrawItemInInventory(itemForMove, itemForMove.Amount, indexFinal);
        
        //delete item in slot initial
        itemInventory[indexInitial] = null;
        InventoryUI.Instance.DrawItemInInventory(null, 0, indexInitial);
    }
    private void UseItem(int index)
    {
        if (itemInventory[index] == null)
        {
            return;
        }

        if (itemInventory[index].UseItem())
        {
            DeleteItem(index);
        }
    }
    #region Event

    private void SlotInteractionResponse(TypeInteraction type, int index)
    {
        switch (type)
        {
            case TypeInteraction.Use:
                UseItem(index);
                break;
            case TypeInteraction.Remove:
                break;
        }
    }
    private void OnEnable()
    {
        InventorySlot.EventSlotInteraction += SlotInteractionResponse;
    }

    private void OnDisable()
    {
        InventorySlot.EventSlotInteraction -= SlotInteractionResponse;
    }

    #endregion
}
