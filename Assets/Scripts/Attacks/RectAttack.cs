using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectAttack : AttackBase
{
    // --- public variables
    
    [SerializeField] public float baseCooldown = 1;
    [SerializeField] public int baseDamage = 1;
    [SerializeField] private float attackDuration = 0.1f;

    private GameObject _hitbox;

    
    // --- private variables
    private float _lastUsedTime;
    
    void Start()
    {
        // adds function which updates attack values to delegate which triggers on level change
        onLevelUp += _SetValues;
        
        // set up starting values for variables
        _lastUsedTime = Time.time;
        _hitbox = transform.Find("Hitbox").gameObject;
        _hitbox.SetActive(false);
        
        Damage = baseDamage;
        Cooldown = baseCooldown;
        
    }

    private void Update()
    {
        // activates attack at intervals equal to Cooldown   
        if (Time.time >= _lastUsedTime + baseCooldown)
        {
            _lastUsedTime = Time.time;
            StartCoroutine(Attack());
        }
    }

    // --- private methods
    private IEnumerator Attack()
    {
        // enables hitbox for an established duration
        _hitbox.SetActive(true);
        yield return new WaitForSeconds(attackDuration);
        _hitbox.SetActive(false);
    }

    private void _SetValues()
    {
        // function responsible for updating values when level changes
        // so the lines of code below dictate the scaling of the attack,
        // and add new abilities (if any) to the attack based on level
        Damage = baseDamage + (Level / 3);
        Cooldown = baseCooldown - (Level-1) * 0.02f;
    }
}
