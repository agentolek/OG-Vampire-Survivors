using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
