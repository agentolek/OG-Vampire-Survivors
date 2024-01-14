using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    [SerializeField] public int gameLength = 120;

    public delegate void OnVictory();
    public static event OnVictory onVictory;

    public delegate void OnDefeat();
    public static event OnDefeat onDefeat;

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    public void WinGame()
    {
        onVictory?.Invoke();
    }

    public void LoseGame()
    {
        onDefeat?.Invoke();
    }
}
