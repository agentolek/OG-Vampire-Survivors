using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private List<Button> _slotButtons;
    
    private void Start()
    {
        _slotButtons = new List<Button>();
        foreach (Transform child in transform)
        {
            _slotButtons.Add(child.GetComponent<Button>());
        }
    }
    
    private void SetSlotImage(Sprite image, int slot)
    {
        _slotButtons[slot].image.sprite = image;
    }
}
