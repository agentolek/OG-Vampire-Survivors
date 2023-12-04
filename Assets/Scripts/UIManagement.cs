using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    [SerializeField]
    public Image healthBar;
    [SerializeField]
    public Image xpBar;

    private float _xHpSize;
    private float _xXpSize;


    private void Start()
    {
        _xHpSize = healthBar.rectTransform.sizeDelta.x;
        _xXpSize = xpBar.rectTransform.sizeDelta.x;
    }


    
    public void UpdateHp(float newHp, float newMaxHp)
    {
        healthBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newHp/newMaxHp * _xHpSize);
    }

    public void UpdateXp(float newXp, float newMaxXp)
    {
        xpBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newXp/newMaxXp * _xXpSize);
    }

}

