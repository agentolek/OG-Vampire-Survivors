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
    private Collider2D _spriteCollider;

    private void Start()
    {
        _inventoryManager = GetComponent<InventoryManager>();
        _spritePreview = spritePreviewObject.GetComponent<SpriteRenderer>();
    }

    private PickupOrb FindClosestOrb()
    {
        GameObject closestOrb = null;
        float closestDistance = Mathf.Infinity;
        LayerMask mask = LayerMask.GetMask("ItemOrb");
        Collider2D[] collidersHit = Physics2D.OverlapCircleAll(transform.position, maxPickupDistance, mask);
        foreach (Collider2D col in collidersHit)
        {
            float distance = Vector3.Distance(col.transform.position, transform.position);
            Debug.Log("Distance to " + col.name + ": " + distance);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestOrb = col.gameObject;
            }
        }
        return closestOrb ? closestOrb.GetComponent<PickupOrb>() : null;
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
    // TODO: there should be a way to exit placement mode without placing an item
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
        item.GetComponent<Item>().DisappearFromGameWorld();
        GameObject testSpawn = Instantiate(item, _placingItem.transform.position, spritePreviewObject.transform.rotation);
        
        bool temp = testSpawn.GetComponent<Item>().IsTouching();
        Destroy(testSpawn);
        item.GetComponent<Item>().AppearInGameWorld();

        return !temp;
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mouseInWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mouseInWorldPosition.z = 0;
        return mouseInWorldPosition;
    }
}
