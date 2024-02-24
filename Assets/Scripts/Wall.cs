using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wall : Item
{
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;

    private void Start()
    {
        existsInGameWorld = true;
    }

    public Wall()
    {
        itemName = "Wall";
        NumberOfOrientations = 4;
    }

    // start cannon placement
    public override void Use()
    {
        Debug.Log("Wall used");
    }
}
