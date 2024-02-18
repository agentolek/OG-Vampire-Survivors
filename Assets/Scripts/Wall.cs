using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wall : Item
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private void Start()
    {
        itemCollider = GetComponent<BoxCollider2D>();
        existsInGameWorld = true;
    }

    public Wall()
    {
        itemName = "Wall";
        _numberOfOrientations = 4;
    }

    // start cannon placement
    public override void use()
    {
        Debug.Log("Wall used");
    }
}
