using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PickupOrb : Item
{
    [SerializeField] public GameObject containedObject;
    [SerializeField] private SpriteRenderer innerIcon;
    
    [HideInInspector]
    public Item containedItem;

    private void Start()
    {
        existsInGameWorld = true;
        containedItem = containedObject.GetComponent<Item>();
        SetIconSprite();
    }

    private void SetIconSprite()
    {
        innerIcon.sprite = containedItem.GetSprite();
        // TODO: this doesn't work, fix it
        innerIcon.transform.localScale = Vector3.one * containedItem.iconScale;

    }
    
    public override void Use()
    {
        //this is empty by design
    }
}
