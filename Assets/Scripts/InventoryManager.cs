using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private Item _heldItem;

    public Item getItem()
    {
        if (_heldItem)
        {
            Debug.Log("Got here!!!");
            return _heldItem;
        }
        return null;
    }

    public void addItem(Item item)
    {
        _heldItem = item;
        Debug.Log("Item added to inventory: " + item.itemName);
    }

    public void removeItem()
    {
        _heldItem = null;
    }
}
