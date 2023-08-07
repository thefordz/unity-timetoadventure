using UnityEngine;

[CreateAssetMenu(menuName = "Items/Health Postion")]
public class ItemHealthPotion : InventoryItem
{
    [Header("Potion info")]
    public float HPRestauracion;

    public override bool UseItem()
    {
        if (Inventory.Instance.Character.CharacterHealth.canHealth)
        {
            Inventory.Instance.Character.CharacterHealth.RestoreHealth(HPRestauracion);
            return true;
        }

        return false;
    }
    
    
}
