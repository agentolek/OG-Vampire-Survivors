using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    private InventoryManager _inventoryManager;
    [SerializeField] GameObject spritePreview;
    private bool _placementMode;
    private Item _placingItem;
    [SerializeField] float maxPickupDistance;

    private void Start()
    {
        _inventoryManager = GetComponent<InventoryManager>();
    }

    private Item FindClosestItem()
    {
        Item closestItem = null;
        float closestDistance = maxPickupDistance;
        foreach (Item item in FindObjectsByType<Item>(FindObjectsSortMode.None))
        {
            float distance = Vector3.Distance(item.transform.position, transform.position);
            Debug.Log("Distance to " + item.itemName + ": " + distance);
            if (item.existsInGameWorld && distance < closestDistance)
            {
                closestDistance = distance;
                closestItem = item;
            }
        }
        return closestItem;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Item closestItem = FindClosestItem();
            if (closestItem)
            {
                // _inventoryManager.addItem(closestItem);
                closestItem.DisappearFromGameWorld();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            // _placingItem = _inventoryManager.getItem();
            if (_placingItem)
            {
                EnterPlacementMode(_placingItem);
            }
        }

        if (_placementMode)
        {
            _placingItem.transform.position = GetMousePosition();
            ShowItemPreview(_placingItem);
            if (Input.GetMouseButtonDown(0))
            {
                _placingItem.AppearInGameWorld(_placingItem.transform);
                // _inventoryManager.removeItem();
                ExitPlacementMode();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                ChangeItemOrientation(_placingItem);
            }
        }
    }

    public void EnterPlacementMode(Item item)
    {
        Debug.Log("Placement mode entered");
        _placingItem = item;
        Sprite sprite = item.GetSprite();
        spritePreview.GetComponent<SpriteRenderer>().sprite = sprite;
        _placementMode = true;
    }

    private void ExitPlacementMode()
    {
        Debug.Log("Placement mode exited");
        spritePreview.GetComponent<SpriteRenderer>().sprite = null;
        _placementMode = false;
        _placingItem = null;
    }

    private void ChangeItemOrientation(Item item)
    {
        Debug.Log("Item orientation changed by " + 360 / item.NumberOfOrientations + " degrees");
        item.transform.Rotate(0, 0, 360 / item.NumberOfOrientations);
    }

    private void ShowItemPreview(Item item)
    {
        if (CanPlaceItem(item, item.transform))
        {
            spritePreview.GetComponent<SpriteRenderer>().color = Color.green;
            spritePreview.transform.position = item.transform.position;
            spritePreview.transform.rotation = item.transform.rotation;
        }
        else
        {
            spritePreview.GetComponent<SpriteRenderer>().color = Color.red;
            spritePreview.transform.position = transform.position;
            spritePreview.transform.rotation = transform.rotation;
        }
    }

    private bool CanPlaceItem(Item item, Transform itemTransform)
    {
        return true;
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mouseInWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mouseInWorldPosition.z = 0;
        return mouseInWorldPosition;
    }
}
