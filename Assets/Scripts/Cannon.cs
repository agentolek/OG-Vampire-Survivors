using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cannon : Item
{
    private SpriteRenderer spriteRenderer;
    private CapsuleCollider2D capsuleCollider;

    private void Start()
    {
        itemCollider = GetComponent<CapsuleCollider2D>();
        existsInGameWorld = true;
    }

    public Cannon()
    {
        _numberOfOrientations = 4;
        itemName = "Cannon";
    }

    // start cannon placement
    public override void use()
    {
        Debug.Log("Cannon used");
    }
}
