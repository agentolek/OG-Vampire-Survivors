using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Nexus : MonoBehaviour
{
    [SerializeField] public int maxHp = 50;
    [SerializeField] public int testHp = 0;
    public int hp;
    public Image healthBar;

    public List<Sprite> sprites;
    
    private GameManagement _gameManager;
    private float _xHpSize;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManagement>();
        _xHpSize = healthBar.rectTransform.sizeDelta.x;
        hp = maxHp;
        ChangeHp(testHp - maxHp);
    }

    private void ChangeHp(int value)
    {
        hp += value;
        UpdateSprite((float)hp/maxHp);
        UpdateHealthBar();
        if (hp <= 0)
        {
            _gameManager.FinishGame();
        }
    }

    private void UpdateHealthBar()
    {
        healthBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)hp / maxHp * _xHpSize);
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
