using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.UI;

public class Timer : MonoBehaviour
{
    public float TotalTime { get; private set; }
    private int _timeToWin;
    [SerializeField] public TMP_Text timerText;

    private GameManagement _gameManagement;

    private void Start()
    {
        _gameManagement = GameObject.Find("GameManager").GetComponent<GameManagement>();
        _timeToWin = _gameManagement.gameLength;
    }

    private void Update()
    {
        TotalTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(TotalTime / 60);
        int seconds = Mathf.FloorToInt(TotalTime % 60);
        timerText.text = $"{minutes}:{(seconds < 10 ? "0" + seconds : seconds)}";

        if (_timeToWin <= TotalTime)
        {
            GameManagement.GameWon = true;
            _gameManagement.FinishGame();
        }
    }
}
