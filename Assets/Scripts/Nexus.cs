using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Nexus : MonoBehaviour
{
    [SerializeField] public int maxHp = 50;
    [SerializeField] public int testHp = 0;
    public int hp;

    public List<Sprite> sprites;
    
    private UIManagement _uiManager;
    private GameManagement _gameManager;

    private void Start()
    {
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManagement>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManagement>();
        hp = maxHp;
        ChangeHp(-maxHp+testHp);
    }

    private void ChangeHp(int value)
    {
        hp += value;
        UpdateSprite((float)hp/maxHp);
        // _uiManager.UpdateHp(hp, maxHp);
        if (hp <= 0)
        {
            _gameManager.FinishGame();
        }
    }
    
    public void TakeDamage(int damage)
    {
        ChangeHp(-1 * damage);
    }

    private void UpdateSprite(float percentage)
    {
        var spriteNum = 0;
        while (percentage > (double)(spriteNum+1)/sprites.Count)
        {
            spriteNum += 1;
        }

        SpriteRenderer spriteRen = gameObject.GetComponent<SpriteRenderer>();
        spriteRen.sprite = sprites[spriteNum];
    }
}
