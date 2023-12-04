using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddXP : MonoBehaviour
{
    [SerializeField] public int xp = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SendMessage("AddXp", xp, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
