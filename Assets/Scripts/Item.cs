using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Item : MonoBehaviour
{
    public string itemName;
    protected int _numberOfOrientations;
    protected Collider2D itemCollider;
    protected SpriteRenderer itemSpriteRenderer;
    public bool existsInGameWorld;

    private void Awake()
    {
        itemSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public int numberOfOrientations
    {
        get
        {
            return _numberOfOrientations;
        }
    }

    abstract public void use();

    virtual public void disappearFromGameWorld()
    {
        itemCollider.enabled = false;
        itemSpriteRenderer.enabled = false;
        existsInGameWorld = false;
    }
    virtual public void appearInGameWorld(Transform appearTransform)
    {
        transform.position = appearTransform.position;
        itemCollider.enabled = true;
        itemSpriteRenderer.enabled = true;
        existsInGameWorld = true;
    }
    public Sprite getSprite()
    {
        return itemSpriteRenderer.sprite;
    }
}
