using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    [SerializeField] public int gameLength = 120;
    [SerializeField] public int dayNightLength = 30;
    public static bool GameFinished;
    public static bool IsDay = true;
    
    public float TotalTime { get; private set; }
    private float _dayNightCd;

    public static Action onGameFinished;

    // public delegate void OnChangeToDay();
    public event Action OnChangeToDay;

    public event Action OnChangeToNight;


    private void Start()
    {
        _dayNightCd = dayNightLength;
    }

    private void Update()
    {
        _dayNightCd -= Time.deltaTime;
        TotalTime += Time.deltaTime;

        if (_dayNightCd <= 0)
        {
            _dayNightCd = dayNightLength;
            IsDay = !IsDay;
            if (IsDay)
            {
                OnChangeToDay?.Invoke();
            }
            else
            {
                OnChangeToNight?.Invoke();
            }
        }
        
        if (gameLength <= TotalTime)
        {
            GameFinished = true;
            FinishGame();
        }
    }

    public void FinishGame()
    {
        onGameFinished?.Invoke();
    }
}
