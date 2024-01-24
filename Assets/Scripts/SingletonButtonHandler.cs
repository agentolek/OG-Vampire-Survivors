using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonButtonHandler: MonoBehaviour
{
    public void PlayGame()
    {
        SceneManagement.Instance.PlayGame();
    }
    
    public void ShowMenu()
    {
        Debug.Log("Works");
        SceneManagement.Instance.ShowMenu();
    }
    
    public void ShowSettings()
    {
        SceneManagement.Instance.ShowSettings();
    }

    public void ShowUpgrades()
    {
        SceneManagement.Instance.ShowUpgrades();
    }

    public void QuitGame()
    {
        SceneManagement.Instance.QuitGame();
    }
}
