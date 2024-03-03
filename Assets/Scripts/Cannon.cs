using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cannon : Item
{
    private SpriteRenderer _spriteRenderer;
    private CapsuleCollider2D _capsuleCollider;

    private void Start()
    {
        existsInGameWorld = true;
    }

    public Cannon()
    {
        NumberOfOrientations = 4;
        itemName = "Cannon";
    }

    // start cannon placement
    public override void Use()
    {
        Debug.Log("Cannon used");
    }
}
