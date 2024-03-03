using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    private InventoryManager _inventoryManager;
    [SerializeField] GameObject spritePreviewObject;
    private bool _placementMode;
    private GameObject _placingItem;
    private GameObject _clonedItem;
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
                _clonedItem = Instantiate(_placingItem, transform.position, Quaternion.identity);
                EnterPlacementMode();
            }
        }

        if (_placementMode)
        {
            _clonedItem.transform.position = GetMousePosition();
            ShowItemPreview();
            // this just places the item, doesn't call CanPlace method
            if (Input.GetMouseButtonDown(0) && CanPlaceItem())
            {
                Instantiate(_placingItem, _clonedItem.transform.position, _clonedItem.transform.rotation);
                _inventoryManager.RemoveItem();
                ExitPlacementMode();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                ChangeItemOrientation(_clonedItem);
            }
        }
    }

    public void EnterPlacementMode()
    {
        _clonedItem.SetActive(true);
        _clonedItem.GetComponent<Item>().DisappearFromGameWorld();
        _spritePreview.sprite = _placingItem.GetComponent<Item>().GetSprite();
        _placementMode = true;
    }
    
    // TODO: there should be a way to exit placement mode without placing an item
    private void ExitPlacementMode()
    {
        Destroy(_clonedItem);
        _spritePreview.sprite = null;
        _placementMode = false;
        _placingItem = null;
    }

    private void ChangeItemOrientation(GameObject item)
    {
        Item itemComponent = item.GetComponent<Item>();
        item.transform.Rotate(0, 0, (float)360 / itemComponent.NumberOfOrientations);
    }

    private void ShowItemPreview()
    {
        spritePreviewObject.transform.SetPositionAndRotation(_clonedItem.transform.position, _clonedItem.transform.rotation);
        if (CanPlaceItem())
        {
            _spritePreview.color = Color.green;
        }
        else
        {
            _spritePreview.color = Color.red;
        }
    }
    
    private bool CanPlaceItem()
    {
        bool temp = _clonedItem.GetComponent<Item>().IsTouching();

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
