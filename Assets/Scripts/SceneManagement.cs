using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    #region Singleton Creation
    public static SceneManagement Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion
    // private void Start()
    // {
    //     DontDestroyOnLoad(gameObject);
    // }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    
    public void ShowMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ShowSettings()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void ShowUpgrades()
    {
        SceneManager.LoadScene("UpgradesScene");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}