using System;
using UnityEngine;

[Serializable]
public class WaveContentData
{
    public GameObject enemyToSpawn;
    public int amountToSpawn;
    public bool gradualSpawn;
    public float delayBeforeStart;
    public float intervalBetweenSpawns;
    public int spawnDistance;
}
