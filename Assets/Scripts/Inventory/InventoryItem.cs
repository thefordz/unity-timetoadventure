using UnityEngine;

public enum TypesItem
{
    Material,
    Potion,
}
public class InventoryItem : ScriptableObject
{
    [Header("Parameter")] 
    public string ID;
    public string Number;
    public Sprite Icon;
    [TextArea]public string Description;

    [Header("Infomation")] 
    public TypesItem type;
    public bool IsConsumable;
    public bool IsCumulative;
    public int CumulativeMax;
    [HideInInspector] public int Amount;

    public InventoryItem CopyItem()
    {
        InventoryItem newInstance = Instantiate(this);
        return newInstance;
    }

    public virtual bool UseItem()
    {
        return true;
    }

    public virtual bool RemoveItem()
    {
        return true;
    }
    
    
}