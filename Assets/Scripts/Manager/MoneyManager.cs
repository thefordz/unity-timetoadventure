using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : Singleton<MoneyManager>
{
    [SerializeField] private int moneyTest = 100;
    public int MoneyTotel { get; set; }

    private string KEY_Money = "MyGame_Money";

    private void Start()
    {
        PlayerPrefs.DeleteKey(KEY_Money);
        CarryMoney();
    }

    private void CarryMoney()
    {
        MoneyTotel = PlayerPrefs.GetInt(KEY_Money, moneyTest);
    }

    public void AddMoney(int Amount)
    {
        MoneyTotel += Amount;
        PlayerPrefs.SetInt(KEY_Money, MoneyTotel);
        PlayerPrefs.Save();
    }

    public void RemoveMoney(int Amount)
    {
        if (Amount > MoneyTotel)
        {
            return;
        }

        MoneyTotel -= Amount;
        PlayerPrefs.SetInt(KEY_Money, MoneyTotel);
        PlayerPrefs.Save();
        
    }
}
