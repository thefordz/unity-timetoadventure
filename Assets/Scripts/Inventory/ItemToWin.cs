
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Items/Winable Item")]
public class ItemToWin : InventoryItem
{
    
    public override bool UseItem()
    {
        SceneManager.LoadScene("Winner");
        return true;
    }
}
