
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUI : Singleton<InventoryUI>
{
    [Header("Panel Inventory Description")] 
    [SerializeField] private GameObject panelInventoryDescription;
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescripttion;
    
    [SerializeField] private InventorySlot slotPrefab;
    [SerializeField] private Transform container;

    public int IndexSlotForMover { get; private set; }
    public InventorySlot SlotSelection { get; private set; }
    private List<InventorySlot> slotsAvailable = new List<InventorySlot>();

    void Start()
    {
        InitializationInventory();
        IndexSlotForMover = -1;
    }

    private void Update()
    {
        UpdateSlotSelection();
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (SlotSelection != null)
            {
                IndexSlotForMover = SlotSelection.Index;
            }
        }
    }

    private void InitializationInventory()
    {
        for (int i = 0; i < Inventory.Instance.NumberSLots; i++)
        {
            InventorySlot numberSlots = Instantiate(slotPrefab, container);
            numberSlots.Index = i;
            slotsAvailable.Add(numberSlots);
        }
    }

    private void UpdateSlotSelection()
    {
        GameObject goSelection = EventSystem.current.currentSelectedGameObject;
        if (goSelection == null)
        {
            return;
        }

        InventorySlot slot = goSelection.GetComponent<InventorySlot>();
        if (slot != null)
        {
            SlotSelection = slot;
        }
    }
    public void DrawItemInInventory(InventoryItem itemByAdd, int amounted, int itemIndex)
    {
        InventorySlot slot = slotsAvailable[itemIndex];
        if (itemByAdd != null)
        {
            slot.ActiveSlotUI(true);
            slot.UpdateSlotUI(itemByAdd, amounted);
        }
        else
        {
            slot.ActiveSlotUI(false);
        }
    }

    private void UpdateInventoryDescription(int index)
    {
        if (Inventory.Instance.ItemInventory[index] != null)
        {
            itemIcon.sprite = Inventory.Instance.ItemInventory[index].Icon;
            itemName.text = Inventory.Instance.ItemInventory[index].Number;
            itemDescripttion.text = Inventory.Instance.ItemInventory[index].Description;
            panelInventoryDescription.SetActive(true);
        }
        else
        {
            panelInventoryDescription.SetActive(false);
        }
    }

    public void UseItem()
    {
        if (SlotSelection != null)
        {
            SlotSelection.SlotUseItem();
            SlotSelection.SelectionSlot();
        }
    }
    
    #region Event

    public void SlotInteractionResponse(TypeInteraction type, int index)
    {
        if (type == TypeInteraction.Clink)
        {
            UpdateInventoryDescription(index);
        }
    }

    public void OnEnable()
    {
        InventorySlot.EventSlotInteraction += SlotInteractionResponse;
    }

    public void OnDisable()
    {
        InventorySlot.EventSlotInteraction -= SlotInteractionResponse;
    }

    #endregion
    
    
}
