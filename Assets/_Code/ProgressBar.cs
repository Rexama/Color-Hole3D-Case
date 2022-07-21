using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public RectTransform bar;
    public RectTransform completedBar;
    public GameObject goodObjects;

    private int goodObjectCount;
    private float fullBarSize;
    private float stepSize;
    
    public static ProgressBar Instance { get; private set; }
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
    
    private void Start()
    {
        goodObjectCount = goodObjects.transform.childCount;
        fullBarSize = bar.rect.width;
        stepSize = fullBarSize / goodObjectCount;
    }

    public void OnGoodObjectDestroyed()
    {
        completedBar.sizeDelta = new Vector2(completedBar.rect.width + stepSize, completedBar.rect.height);
        goodObjectCount--;
        if (goodObjectCount == 0)
        {
            Debug.Log("level end");
            GameManager.Instance.OnLevelEnd();
        }
    }

    
    
}
