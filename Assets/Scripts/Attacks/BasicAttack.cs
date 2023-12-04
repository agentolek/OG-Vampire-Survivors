using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    // --- public variables
    
    [SerializeField] public int baseDamage = 1;
    [SerializeField] private int level = 1;
    [SerializeField] public float baseCooldown = 1;

    private GameObject _hitbox;

    
    // --- private variables
    private float _lastUsedTime;
    
    void Start()
    {
        _lastUsedTime = Time.time;
        _hitbox = transform.Find("Hitbox").gameObject;
        _hitbox.SetActive(false);
        _hitbox.GetComponent<Hitbox>().Damage = baseDamage;
    }

    private void Update()
    {
        if (Time.time >= _lastUsedTime + baseCooldown)
        {
            _lastUsedTime = Time.time;
            StartCoroutine(Attack());
        }
    }

    // --- private methods
    private IEnumerator Attack()
    {
        _hitbox.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        _hitbox.SetActive(false);
    }
    
    
    // --- public methods
    public void LevelUp()
    {
        // scaling for attack goes here
        level += 1;
        if (level % 2 == 0)
        {
            _hitbox.GetComponent<Hitbox>().Damage += 1;
        }
        Debug.Log(level);

        baseCooldown *= 0.98f;
    }
}
