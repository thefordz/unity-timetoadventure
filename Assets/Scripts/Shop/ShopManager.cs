
using System;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header("Config")] [SerializeField] private FishShop fishShopPrefabs;
    [SerializeField] private Transform panelContainer;

    [Header("Fishes")] 
    [SerializeField] private FishSale[] fishesAvaliable;

    private void Start()
    {
        LoadItemSale();
    }

    private void LoadItemSale()
    {
        for (int i = 0; i < fishesAvaliable.Length; i++)
        {
            FishShop fishShop = Instantiate(fishShopPrefabs, panelContainer);
            fishShop.ConfigFishSale(fishesAvaliable[i]);
        }
    }

}
