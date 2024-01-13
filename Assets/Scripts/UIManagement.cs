using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    [SerializeField]
    public Image healthBar;
    [SerializeField]
    public Image xpBar;

    [SerializeField] public TMP_Text timerText;
    
    private float _xHpSize;
    private float _xXpSize;
    public float TotalTime { get; set; }


    private void Start()
    {
        _xHpSize = healthBar.rectTransform.sizeDelta.x;
        _xXpSize = xpBar.rectTransform.sizeDelta.x;
    }

    private void Update()
    {
        TotalTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(TotalTime/60);
        int seconds = Mathf.FloorToInt(TotalTime % 60);
        timerText.text = $"{minutes}:{(seconds < 10 ? "0" + seconds : seconds)}";
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

