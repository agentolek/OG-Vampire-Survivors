using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    [SerializeField] public int gameLength = 120;

    public void WinGame()
    {
        // TODO: add win screen
        Debug.Log("you won");
        SceneManagement.Instance.ShowMenu();
    }

    public void LoseGame()
    {
        // TODO: add lose screen
        Debug.Log("you lost");
        SceneManagement.Instance.ShowMenu();
    }
}
