using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private Item heldItem;

    public void addItem(Item item)
    {
        heldItem = item;
        Debug.Log("Item added to inventory: " + item.itemName);
    }

    public Item getHeldItem()
    {
        if (heldItem != null)
        {
            return heldItem;
        }
        else
        {
            Debug.Log("No item held");
            return null;
        }
    }

    public void removeItem()
    {
        heldItem = null;
        Debug.Log("Item removed from inventory");
    }
}
