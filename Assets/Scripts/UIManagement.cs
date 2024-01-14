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
    // [SerializeField] public Timer timer;
    [SerializeField] public GameObject inGameUI;
    [SerializeField] public GameObject gameFinishedUI;
    [SerializeField] public TMP_Text levelInfoText;
    [SerializeField] public TMP_Text titleText;
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
        GameManagement.onGameFinished += _HideInGameUI;
        GameManagement.onGameFinished += _ShowGameFinishedUI;
        GameManagement.onGameFinished += _SetLevelInfoText;
        GameManagement.onGameFinished += _SetTitleText;
    }

    private void OnDisable()
    {
        GameManagement.onGameFinished -= _HideInGameUI;
        GameManagement.onGameFinished -= _ShowGameFinishedUI;
        GameManagement.onGameFinished -= _SetLevelInfoText;
        GameManagement.onGameFinished -= _SetTitleText;

    }

    private void _HideInGameUI()
    {
        inGameUI.SetActive(false);
    }

    private void _ShowGameFinishedUI()
    {
        gameFinishedUI.SetActive(true);
    }

    public void UpdateHp(float newHp, float newMaxHp)
    {
        healthBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newHp / newMaxHp * _xHpSize);
    }

    public void UpdateXp(float newXp, float newMaxXp)
    {
        xpBar.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newXp / newMaxXp * _xXpSize);
    }

    // public float GetTimerValue()
    // {
    //     return timer.TotalTime;
    // }

    private void _SetLevelInfoText()
    {
        levelInfoText.text = "Achieved level: " + player.GetComponent<PlayerController>().PlayerLevel;
    }

    private void _SetTitleText()
    {
        titleText.text = GameManagement.GameWon ? "Victory Royale!" : "Catastrophic failure!";
    }
}

