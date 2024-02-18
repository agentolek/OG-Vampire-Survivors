using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private Item heldItem;

    public Item getItem()
    {
        if (heldItem != null)
        {
            return heldItem;
        }
        return null;
    }

    public void addItem(Item item)
    {
        heldItem = item;
        Debug.Log("Item added to inventory: " + item.itemName);
    }

    public void removeItem()
    {
        heldItem = null;
    }
}
