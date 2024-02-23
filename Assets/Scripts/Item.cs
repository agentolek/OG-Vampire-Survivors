using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string itemName;
    protected Collider2D ItemCollider;
    protected SpriteRenderer ItemSpriteRenderer;
    [HideInInspector]
    public bool existsInGameWorld;

    private void Awake()
    {
        ItemSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public int NumberOfOrientations { get; protected set; }

    public abstract void Use();

    // to też nie wiem czy jest dobrze, bo nie znika dzieci Item jak jakieś mają!
    public virtual void DisappearFromGameWorld()
    {
        ItemCollider.enabled = false;
        ItemSpriteRenderer.enabled = false;
        existsInGameWorld = false;
        foreach (Transform child in transform.GetComponentsInChildren<Transform>())
        {
            child.gameObject.SetActive(false);
        }
    }
    public virtual void AppearInGameWorld(Transform appearTransform)
    {
        transform.position = appearTransform.position;
        ItemCollider.enabled = true;
        ItemSpriteRenderer.enabled = true;
        foreach (Transform child in transform.GetComponentsInChildren<Transform>())
        {
            child.gameObject.SetActive(true);
        }
        existsInGameWorld = true;
    }
    public Sprite GetSprite()
    {
        return ItemSpriteRenderer.sprite;
    }
}
