using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wall : Item
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public Wall()
    {
        itemName = "Wall";
        NumberOfOrientations = 4;
    }

    // start cannon placement
    public override void use()
    {
        Debug.Log("Wall used");
    }

    // used when picked up by player
    public override void disappearFromGameWorld()
    {
        spriteRenderer.enabled = false;
        boxCollider.enabled = false;
    }

    // used when placed by player
    public override void appearInGameWorld(Transform transform)
    {
        spriteRenderer.enabled = true;
        boxCollider.enabled = true;
        this.transform.position = transform.position;
    }
}
