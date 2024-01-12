using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PlayerController : MonoBehaviour
{
    // --- public variables

    [SerializeField] public int hp = 10;
    [SerializeField] public int maxHp = 10;

    [SerializeField] public int xp = 0;
    [SerializeField] public int maxXp = 10;
    
    [SerializeField] List<GameObject> attacks;
    public int PlayerLevel { get; set; }
    
    // [SerializeField] public float kbForce = 0.5f;
    // [SerializeField] public float kbTime = 0.2f;
    
    
    // --- private variables
    
    private SpriteRenderer _sprite;
    private UIManagement _uiManager;
    
    // --- private methods
    void Start()
    {
        _sprite = gameObject.GetComponent<SpriteRenderer>();
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManagement>();
        _uiManager.UpdateXp(xp, maxXp);
        SetupAttacks();
    }
    
    IEnumerator ChangeColor(Color color)
    {
        
        _sprite.color = color;
        yield return new WaitForSeconds(0.2f);
        _sprite.color = Color.white;

    }
    
    private void ChangeHp(int value)
    {
        hp = hp+value;
        _uiManager.UpdateHp(hp, maxHp);
        if (hp <= 0)
        {
            Die();
        }
    }

    private void LevelUp()
    {
        Random random = new Random();
        
        // changes player stats
        PlayerLevel += 1;
        maxHp += 2;
        ChangeHp(2);
        xp -= maxXp;
        maxXp = Mathf.RoundToInt(1.2f * maxXp);
        
        // selects random attack to level up or activate
        // TODO: this will enter infinite loop if all attacks are at their max level.
        GameObject attack = attacks[random.Next(attacks.Count)];
        while (attack.GetComponent<AttackBase>().Level >= attack.GetComponent<AttackBase>().maxLevel)
        {
            attack = attacks[random.Next(attacks.Count)];
        }

        if (!attack.activeSelf)
        {
            attack.SetActive(true);
        }
        else
        {
            attack.GetComponent<AttackBase>().Level += 1;
        }
    }


    private void SetupAttacks()
    {
        foreach (var attack in attacks)
        {
            attack.SetActive(false);
        }
        attacks[0].SetActive(true);
        
    }
    
    
    // --- public methods
    public void TakeDamage(int damage, GameObject toBeKnocked = null)
    {
        ChangeHp(-1*damage);
        
        StartCoroutine(ChangeColor(Color.red));
    }


    public void AddXp(int value)
    {
        xp += value;
        if (xp >= maxXp)
        {
            LevelUp();
            AddXp(0);
        }
        
        _uiManager.UpdateXp(xp, maxXp);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    
}
