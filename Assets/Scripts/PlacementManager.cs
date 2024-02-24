using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    private InventoryManager _inventoryManager;
    [SerializeField] GameObject spritePreviewObject;
    private bool _placementMode;
    private GameObject _placingItem;
    [SerializeField] float maxPickupDistance;

    private SpriteRenderer _spritePreview;

    private void Start()
    {
        _inventoryManager = GetComponent<InventoryManager>();
        _spritePreview = spritePreviewObject.GetComponent<SpriteRenderer>();
    }

    private PickupOrb FindClosestOrb()
    {
        PickupOrb closestOrb = null;
        float closestDistance = maxPickupDistance;
        // this has got to be wrong, will find and calculate distance to every single PickupOrb in the world, which seems expensive
        // can probably be done better with a raycast around the player or smth
        foreach (PickupOrb orb in FindObjectsByType<PickupOrb>(FindObjectsSortMode.None))
        {
            float distance = Vector3.Distance(orb.transform.position, transform.position);
            Debug.Log("Distance to " + orb.itemName + ": " + distance);
            if (orb.existsInGameWorld && distance < closestDistance)
            {
                closestDistance = distance;
                closestOrb = orb;
            }
        }
        return closestOrb;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickupOrb closestOrb = FindClosestOrb();
            if (closestOrb)
            {
                _inventoryManager.AddItem(closestOrb);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _placingItem = _inventoryManager.GetItem();
            if (_placingItem)
            {
                EnterPlacementMode(_placingItem);
            }
        }

        if (_placementMode)
        {
            _placingItem.transform.position = GetMousePosition();
            ShowItemPreview(_placingItem);
            // this just places the item, doesn't call CanPlace method
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(_placingItem, _placingItem.transform.position, spritePreviewObject.transform.rotation);
                _inventoryManager.RemoveItem();
                ExitPlacementMode();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                ChangeItemOrientation(_placingItem);
            }
        }
    }

    public void EnterPlacementMode(GameObject item)
    {
        Debug.Log("Placement mode entered");
        _placingItem = item;
        _spritePreview.sprite = item.GetComponent<Item>().GetSprite();
        _placementMode = true;
    }

    private void ExitPlacementMode()
    {
        Debug.Log("Placement mode exited");
        _spritePreview.sprite = null;
        _placementMode = false;
        _placingItem = null;
    }

    private void ChangeItemOrientation(GameObject item)
    {
        Item itemComponent = item.GetComponent<Item>();
        Debug.Log("Item orientation changed by " + 360 / itemComponent.NumberOfOrientations + " degrees");
        item.transform.Rotate(0, 0, (float)360 / itemComponent.NumberOfOrientations);
    }

    private void ShowItemPreview(GameObject item)
    {
        if (CanPlaceItem(item))
        {
            _spritePreview.color = Color.green;
            spritePreviewObject.transform.SetPositionAndRotation(item.transform.position, item.transform.rotation);
        }
        else
        {
            _spritePreview.color = Color.red;
            spritePreviewObject.transform.SetPositionAndRotation(item.transform.position, item.transform.rotation);

        }
    }
    
    // TODO: make CanPlaceItem an actual function, instead of this placeholder
    private bool CanPlaceItem(GameObject item)
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
