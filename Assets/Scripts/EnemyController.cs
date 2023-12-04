using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // --- private variables
    private PlayerController _player;
    
    // --- public variables
    [SerializeField] public int damage = 1;
    [SerializeField] public int hp = 3;
    [SerializeField] public int maxHp = 3;
    [SerializeField] public GameObject xpOrb;
    
    
    // --- private methods
    void Start()
    {
        _player = GameObject.Find("Player1").GetComponent<PlayerController>();
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            _player.TakeDamage(damage, gameObject);
        }
    }
    
    // --- public methods

    public void TakeDamage(int value)
    {
        hp = hp - value;
        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(xpOrb, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
