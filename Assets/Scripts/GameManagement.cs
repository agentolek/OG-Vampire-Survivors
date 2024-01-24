using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    [SerializeField] public int gameLength = 120;
    public static bool GameWon = false;

    public delegate void OnGameFinished();
    public static event OnGameFinished onGameFinished;

    public void FinishGame()
    {
        onGameFinished?.Invoke();

    }
}
