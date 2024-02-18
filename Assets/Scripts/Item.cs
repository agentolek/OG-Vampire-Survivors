using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Item : MonoBehaviour
{
    public string itemName;
    protected int _numberOfOrientations;
    public int NumberOfOrientations { get; set; }

    abstract public void use();

    abstract public void disappearFromGameWorld();
    abstract public void appearInGameWorld(Transform transform);
    public Sprite getSprite()
    {
        return GetComponent<SpriteRenderer>().sprite;
    }
}
