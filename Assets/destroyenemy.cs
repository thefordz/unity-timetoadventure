using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyenemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
        }
    }
}
