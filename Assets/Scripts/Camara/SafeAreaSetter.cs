using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class SafeAreaSetter : MonoBehaviour
{
    private void Awake()
    {
        var rectTranform = GetComponent<RectTransform>();
        var safeArea = Screen.safeArea;
        var anchorMin = safeArea.position;
        var anchorMax = anchorMin + safeArea.size;

        anchorMin.x /= Screen.width;
        anchorMin.y /= Screen.height;
        anchorMax.x /= Screen.width;
        anchorMax.y /= Screen.height;

        rectTranform.anchorMin = anchorMin;
        rectTranform.anchorMax = anchorMax;
    }
}
