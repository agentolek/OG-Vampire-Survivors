using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    private InventoryManager inventoryManager;
    [SerializeField] GameObject spritePreview;
    private bool placementMode = false;
    private Item placingItem;

    private void Start()
    {
        inventoryManager = GetComponent<InventoryManager>();
    }

    private Item findClosestItem()
    {
        Item closestItem = null;
        float closestDistance = Mathf.Infinity;
        foreach (Item item in FindObjectsOfType<Item>())
        {
            float distance = Vector3.Distance(item.transform.position, transform.position);
            if (distance < closestDistance)
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
            Item closestItem = findClosestItem();
            if (closestItem != null)
            {
                inventoryManager.addItem(closestItem);
                closestItem.disappearFromGameWorld();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            enterPlacementMode(inventoryManager.getHeldItem());
        }

        if (placementMode)
        {
            placingItem.transform.position = getMousePosition();
            showItemPreview(placingItem, placingItem.transform);
            if (Input.GetMouseButtonDown(0))
            {
                placingItem.appearInGameWorld(placingItem.transform);
                inventoryManager.removeItem();
                exitPlacementMode();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                changeItemOrientation(placingItem);
            }
        }
    }

    public void enterPlacementMode(Item item)
    {
        Debug.Log("Placement mode entered");
        placingItem = item;
        Sprite sprite = item.getSprite();
        spritePreview.GetComponent<SpriteRenderer>().sprite = sprite;
        placementMode = true;
    }

    private void exitPlacementMode()
    {
        Debug.Log("Placement mode exited");
        spritePreview.GetComponent<SpriteRenderer>().sprite = null;
        placementMode = false;
        placingItem = null;
    }

    private void changeItemOrientation(Item item)
    {
        Debug.Log("Item orientation changed by " + 360 / item.numberOfOrientations + " degrees");
        item.transform.Rotate(0, 0, 360 / item.numberOfOrientations);
    }

    private void showItemPreview(Item item, Transform transform)
    {
        if (canPlaceItem(item, transform))
        {
            spritePreview.GetComponent<SpriteRenderer>().color = Color.green;
            spritePreview.transform.position = transform.position;
            spritePreview.transform.rotation = transform.rotation;
        }
        else
        {
            spritePreview.GetComponent<SpriteRenderer>().color = Color.red;
            spritePreview.transform.position = transform.position;
            spritePreview.transform.rotation = transform.rotation;
        }
    }

    private bool canPlaceItem(Item item, Transform transform)
    {
        return true;
    }

    private Vector3 getMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
