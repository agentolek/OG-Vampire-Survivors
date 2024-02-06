using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] public TMP_Text timerText;

    private GameManagement _gameManagement;

    private void Start()
    {
        _gameManagement = GameObject.Find("GameManager").GetComponent<GameManagement>();
    }

    private void Update()
    {
        var currTime = _gameManagement.TotalTime;
        var minutes = Mathf.FloorToInt(currTime / 60);
        var seconds = Mathf.FloorToInt(currTime % 60);
        timerText.text = $"{minutes}:{(seconds < 10 ? "0" + seconds : seconds)}";
    }
}
