using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cannon : Item
{
    private SpriteRenderer spriteRenderer;
    private CapsuleCollider2D capsuleCollider;

    private void Awake()
    {
        numberOfOrientations = 4;
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    public Cannon()
    {
        itemName = "Cannon";
    }

    // start cannon placement
    public override void use()
    {
        Debug.Log("Cannon used");
    }

    // used when picked up by player
    public override void disappearFromGameWorld()
    {
        spriteRenderer.enabled = false;
        capsuleCollider.enabled = false;
    }

    // used when placed by player
    public override void appearInGameWorld(Transform transform)
    {
        spriteRenderer.enabled = true;
        capsuleCollider.enabled = true;
        this.transform.position = transform.position;
    }
}
