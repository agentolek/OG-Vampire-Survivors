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
        ItemCollider = GetComponent<CircleCollider2D>();
        existsInGameWorld = true;
        containedItem = containedObject.GetComponent<Item>();
        SetIconSprite();
    }

    private void SetIconSprite()
    {
        innerIcon.sprite = containedItem.GetSprite();
        innerIcon.size = new Vector2(2, 2);

    }
    
    public override void Use()
    {
        //this is empty by design
    }
}
