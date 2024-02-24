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
        //TODO: icons no longer show up and I have no idea why
        innerIcon.sprite = containedItem.GetSprite();
        innerIcon.transform.localScale = Vector3.one * containedItem.iconScale;
    }
    
    public override void Use()
    {
        //this is empty by design
    }
}
