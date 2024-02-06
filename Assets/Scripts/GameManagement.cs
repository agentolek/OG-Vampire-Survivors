using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    [SerializeField] public int gameLength = 120;
    public static bool GameWon = false;
    
    public float TotalTime { get; private set; }

    public delegate void OnGameFinished();
    public static event OnGameFinished onGameFinished;

    private void Update()
    {
        TotalTime += Time.deltaTime;
        
        if (gameLength <= TotalTime)
        {
            GameWon = true;
            FinishGame();
        }
    }

    public void FinishGame()
    {
        onGameFinished?.Invoke();
    }
}
