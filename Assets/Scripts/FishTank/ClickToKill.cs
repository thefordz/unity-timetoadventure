using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToKill : MonoBehaviour
{
    public int startCountClick = 0;
    public int endCountClink ;
    private void OnMouseDown()
    {
        KillFish();
    }
    
    public void KillFish()
    {
        startCountClick++;
        Debug.Log($"Click : {startCountClick}");
        if (startCountClick == endCountClink)
        {
            Destroy(gameObject);
            startCountClick = 0;
            
        }
    }
}
