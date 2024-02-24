using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string itemName;
    [SerializeField] protected Collider2D itemCollider;
    [SerializeField] protected SpriteRenderer itemSpriteRenderer;
    [HideInInspector]
    public bool existsInGameWorld;

    [SerializeField] public float iconScale = 1;

    // private void Awake()
    // {
    //     ItemSpriteRenderer = GetComponent<SpriteRenderer>();
    // }

    public int NumberOfOrientations { get; protected set; }

    public abstract void Use();
    
    public virtual void DisappearFromGameWorld()
    {
        itemCollider.isTrigger = true;
        itemSpriteRenderer.enabled = false;
        existsInGameWorld = false;
        foreach (Transform child in transform.GetComponentsInChildren<Transform>())
        {
            child.gameObject.SetActive(false);
        }
    }
    public virtual void AppearInGameWorld()
    {
        itemCollider.isTrigger = false;
        itemSpriteRenderer.enabled = true;
        foreach (Transform child in transform.GetComponentsInChildren<Transform>())
        {
            child.gameObject.SetActive(true);
        }
        existsInGameWorld = true;
    }
    public Sprite GetSprite()
    {
        return itemSpriteRenderer.sprite;
    }
    
    public bool IsTouching()
    {
        ContactFilter2D filter = new ContactFilter2D().NoFilter();
        Collider2D[] _ = { };
        if (Physics2D.OverlapCollider(itemCollider, filter, _) > 0)
        {
            return true;
        }

        return false;
    }
}
