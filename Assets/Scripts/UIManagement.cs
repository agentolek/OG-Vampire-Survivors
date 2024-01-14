using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    [SerializeField] public Image healthBar;
    [SerializeField] public Image xpBar;
    [SerializeField] public Timer timer;
    [SerializeField] public GameObject inGameUI;
    [SerializeField] public GameObject victoryUI;
    [SerializeField] public TMP_Text levelInfoText;
    [SerializeField] public GameObject player;
    private float _xHpSize;
    private float _xXpSize;

    private void Start()
    {
        _xHpSize = healthBar.rectTransform.sizeDelta.x;
        _xXpSize = xpBar.rectTransform.sizeDelta.x;
    }

    private void OnEnable()
    {
        GameManagement.onVictory += _HideInGameUI;
        GameManagement.onVictory += _ShowVictoryUI;
        GameManagement.onVictory += _SetLevelInfoText;
    }

    private void OnDisable()
    {
        GameManagement.onVictory -= _HideInGameUI;
        GameManagement.onVictory -= _ShowVictoryUI;
        GameManagement.onVictory -= _SetLevelInfoText;

    }

    private void _HideInGameUI()
    {
        inGameUI.SetActive(false);
    }

    private void _ShowVictoryUI()
    {
        victoryUI.SetActive(true);
    }

    public void UpdateHp(float newHp, float newMaxHp)
    {
        healthBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newHp / newMaxHp * _xHpSize);
    }

    public void UpdateXp(float newXp, float newMaxXp)
    {
        xpBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newXp / newMaxXp * _xXpSize);
    }

    public float GetTimerValue()
    {
        return timer.TotalTime;
    }

    private void _SetLevelInfoText()
    {
        int playerLevel = player.GetComponent<PlayerController>().PlayerLevel;
        levelInfoText.text = "Achieved level: " + playerLevel;
    }
}

