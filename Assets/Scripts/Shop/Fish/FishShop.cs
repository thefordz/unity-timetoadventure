using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FishShop : MonoBehaviour
{
    [Header("Config")] [SerializeField] private Image fishIcon;
    [SerializeField] private TextMeshProUGUI fishName;
    [SerializeField] private TextMeshProUGUI fishCost;

    //[SerializeField] private TextMeshProUGUI amountToBuy;

    public FishSale FishLoad { get; private set; }

    private int amount;
    private int initialCost;

    private int currentCost;

    //private GameObject fishPrefabs;
    [SerializeField] private Transform SpawnPos;

    private void Update()
    {
        //amountToBuy.text = amount.ToString();
        fishCost.text = currentCost.ToString();
    }

    public void ConfigFishSale(FishSale fishSale)
    {
        FishLoad = fishSale;
        fishIcon.sprite = fishSale.Item.Icon;
        fishName.text = fishSale.Item.Number;
        fishCost.text = fishSale.Cost.ToString();
        amount = 1;
        initialCost = fishSale.Cost;
        currentCost = fishSale.Cost;
        //fishPrefabs = fishSale.FishPrefabs;
    }


    public void BuyItem()
    {
        if (MoneyManager.Instance.MoneyTotel >= currentCost)
        {
            Inventory.Instance.AddItem(FishLoad.Item, amount);
            MoneyManager.Instance.RemoveMoney(currentCost);
            amount = 1;
            currentCost = initialCost;
            //Debug.Log($"Spawn {fishName.text} {amount}EA");
            //Debug.Log($"{fishPrefabs.gameObject.transform.position}");
        }




        // For Add more or Delete more
        // public void AddItemToBuy()
        // {
        //     int costShop = initialCost * (amount + 1);
        //     if (MoneyManager.Instance.MoneyTotel >= costShop)
        //     {
        //         amount++;
        //         currentCost = initialCost * amount;
        //     }
        // }
        //
        // public void DeleteItemToBuy()
        // {
        //     if (amount ==1)
        //     {
        //         return;
        //     }
        //
        //     amount--;
        //     currentCost = initialCost * amount;
        // }
    }
}
