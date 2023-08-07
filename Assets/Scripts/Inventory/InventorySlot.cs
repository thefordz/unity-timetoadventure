using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public enum TypeInteraction
{
    Clink,
    Use,
    Remove,
}
public class InventorySlot : MonoBehaviour
{
    public static Action<TypeInteraction, int> EventSlotInteraction;
    
    [SerializeField] private Image itemIcon;
    [SerializeField] private GameObject bgAmount;
    [SerializeField] private Text amountText;
    public int Index { get; set; }

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void UpdateSlotUI(InventoryItem item, int amount)
    {
        itemIcon.sprite = item.Icon;
        amountText.text = amount.ToString();
        
    }

    public void ActiveSlotUI(bool condition)
    {
        itemIcon.gameObject.SetActive(condition);
        bgAmount.SetActive(condition);
    }

    public void SelectionSlot()
    {
        _button.Select();
    }
    public void ClickSlot()
    {
        EventSlotInteraction?.Invoke(TypeInteraction.Clink, Index);
        
        //mover item
        if (InventoryUI.Instance.IndexSlotForMover != -1)
        {
            if (InventoryUI.Instance.IndexSlotForMover != Index)
            {
                //Move
                Inventory.Instance.MoverItem(InventoryUI.Instance.IndexSlotForMover,Index);
            }
        }
    }

    public void SlotUseItem()
    {
        if (Inventory.Instance.ItemInventory[Index] != null)
        {
            EventSlotInteraction?.Invoke(TypeInteraction.Use, Index);
        }
    }
}
