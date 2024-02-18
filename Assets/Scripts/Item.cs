using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string itemName;
    protected Collider2D ItemCollider;
    protected SpriteRenderer ItemSpriteRenderer;
    public bool existsInGameWorld;

    private void Awake()
    {
        ItemSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public int NumberOfOrientations { get; protected set; }

    public abstract void Use();

    public virtual void DisappearFromGameWorld()
    {
        ItemCollider.enabled = false;
        ItemSpriteRenderer.enabled = false;
        existsInGameWorld = false;
    }
    public virtual void AppearInGameWorld(Transform appearTransform)
    {
        transform.position = appearTransform.position;
        ItemCollider.enabled = true;
        ItemSpriteRenderer.enabled = true;
        existsInGameWorld = true;
    }
    public Sprite GetSprite()
    {
        return ItemSpriteRenderer.sprite;
    }
}
