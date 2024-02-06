using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightChanger : MonoBehaviour
{
    private Light2D _globalLight;
    private GameManagement _gameManagement;

    private void Start()
    {
        _globalLight = gameObject.GetComponent<Light2D>();
        _gameManagement = GameObject.Find("GameManager").GetComponent<GameManagement>();
        _gameManagement.OnChangeToDay += DayLightWrapper;
        _gameManagement.OnChangeToNight += NightLightWrapper;
    }

    private void DayLightWrapper()
    {
        StartCoroutine(GradualLightChange(1));
    }
    
    private void NightLightWrapper()
    {
        StartCoroutine(GradualLightChange(0.4f));
    }
    
    
    private IEnumerator GradualLightChange(float targetIntensity, int steps=100)
    {
        var currIntensity = _globalLight.intensity;
        for (var i = 0; i < steps; i++)
        {
            _globalLight.intensity += (targetIntensity - currIntensity) / steps;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.01f);

    }
}
