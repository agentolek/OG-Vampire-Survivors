using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [field: SerializeField]
    public int Damage { get; set; }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.SendMessage("TakeDamage", Damage, SendMessageOptions.DontRequireReceiver);
        }
    }
    
}