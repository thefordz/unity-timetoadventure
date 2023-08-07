using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Recipe
{
    public string Name;
    [Header("1st Material")] 
    public InventoryItem Item1;
    public int Item1AmountRequire;

    [Header("2st Material")] 
    public InventoryItem Item2;
    public int Item2AmountRequire;

    [Header("Result")] 
    public InventoryItem ItemResult;
    public int ItemResultAmount;
}


