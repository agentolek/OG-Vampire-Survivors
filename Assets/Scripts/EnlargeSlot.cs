using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargeSlot : MonoBehaviour
{
    [SerializeField] private float _enlargeFactor = 1.2f;

    public void Enlarge()
    {
        transform.localScale *= _enlargeFactor;
    }
    
    public void Shrink()
    {
        transform.localScale /= _enlargeFactor;
    }
}
