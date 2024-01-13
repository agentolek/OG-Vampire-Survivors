using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float TotalTime { get; set; }
    [SerializeField] public TMP_Text timerText;

    private void Update()
    {
        TotalTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(TotalTime/60);
        int seconds = Mathf.FloorToInt(TotalTime % 60);
        timerText.text = $"{minutes}:{(seconds < 10 ? "0" + seconds : seconds)}";
    }
}
