using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AttackBase : MonoBehaviour
{
    [SerializeField] public int maxLevel = 10;
    
    public int Damage { get; set; }
    public double Cooldown { get; set; }
    
    private int _level = 1;
    public int Level
    {
        get => _level;
        set
        {
            if (CanLevel(value))
            {
                _level = value;
                onLevelUp?.Invoke();
            }
        }
    }
    public delegate void OnLevelUp();
    protected OnLevelUp onLevelUp;


    private bool CanLevel(int newLevel)
    {
        if (0 < newLevel && newLevel <= maxLevel)
        {
            return true;
        }
        return false;
    }
    
}