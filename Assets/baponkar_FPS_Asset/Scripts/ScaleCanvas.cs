using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class ScaleCanvas : MonoBehaviour
{
    void Start()
    {
        RectTransform rt = GetComponent<RectTransform>();
 
        Vector3 screenSize = Camera.main.ViewportToWorldPoint(Vector3.up + Vector3.right);
 
        screenSize *= 02;
 
        float sizeY = screenSize.y / rt.rect.height;
        float sizeX = screenSize.x / rt.rect.width;
 
        rt.localScale = new Vector3(sizeX, sizeY, 1);
    }
}