using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Nexus : MonoBehaviour
{
    [SerializeField] public int maxHp = 50;
    public int hp;

    public List<Sprite> sprites;
    
    private UIManagement _uiManager;
    private GameManagement _gameManager;

    private void Start()
    {
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManagement>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManagement>();
        hp = maxHp;
    }

    private void ChangeHp(int value)
    {
        hp += value;
        _uiManager.UpdateHp(hp, maxHp);
        if (hp <= 0)
        {
            _gameManager.FinishGame();
            UpdateSprite((float)hp/maxHp);
        }
    }
    
    public void TakeDamage(int damage)
    {
        ChangeHp(-1 * damage);
    }

    private void UpdateSprite(float percentage)
    {
        
    }
}
