using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/WaveScriptableObject", order = 1)]
public class Wave : ScriptableObject
{
    public List<WaveContentData> waveContent;
}
