using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private GameObject _heldItem;

    public GameObject GetItem()
    {
        if (_heldItem)
        {
            Debug.Log("Got to GetItem!!!");
            return _heldItem;
        }
        return null;
    }

    public void AddItem(PickupOrb orb)
    {
        _heldItem = orb.containedObject;
        orb.gameObject.SetActive(false);
        Debug.Log("Item added to inventory: " + _heldItem.name);
    }

    public void RemoveItem()
    {
        _heldItem = null;
    }
}
