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
    [SerializeField] public int maxHp = 3;
    [SerializeField] public GameObject xpOrb;

    // --- private variables
    private int _hp = 3;

    // --- private methods
    void Start()
    {
        _hp = maxHp;
        _player = GameObject.Find("Player1").GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        GameManagement.onVictory += _Disappear;
    }

    private void OnDisable()
    {
        GameManagement.onVictory -= _Disappear;
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
        _hp = _hp - value;
        if (_hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(xpOrb, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void _Disappear()
    {
        Destroy(gameObject);
    }
}
