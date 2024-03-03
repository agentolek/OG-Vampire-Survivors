using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PickupOrb : MonoBehaviour
{
    [SerializeField] public GameObject containedObject;
    [SerializeField] private SpriteRenderer innerIcon;
    
    [HideInInspector]
    public Item containedItem;

    private void Start()
    {
        containedItem = containedObject.GetComponent<Item>();
        SetIconSprite();
    }

    private void SetIconSprite()
    {
        innerIcon.sprite = containedItem.GetIcon();
        innerIcon.transform.localScale = Vector3.one * containedItem.iconScale;
    }
}
