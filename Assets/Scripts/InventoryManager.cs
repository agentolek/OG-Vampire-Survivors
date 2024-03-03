using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private GameObject _heldItem;

    public GameObject GetItem()
    {
        return _heldItem ? _heldItem : null;
    }

    public void AddItem(PickupOrb orb)
    {
        _heldItem = orb.containedObject;
        Destroy(orb.gameObject);
        Debug.Log("Item added to inventory: " + _heldItem.name);
    }

    public void RemoveItem()
    {
        _heldItem = null;
    }
}
