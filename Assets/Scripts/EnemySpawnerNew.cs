using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerNew : MonoBehaviour
{
    public GameObject gameManager;
    public List<Wave> waves;
    public Wave defaultWave;

    private GameManagement _gameManagement;
    private int _waveCounter;
    void Start()
    {
        _gameManagement = gameManager.GetComponent<GameManagement>();
        _gameManagement.OnChangeToNight += SpawnWave;
    }

    void SpawnWave()
    {
        Wave currWave = waves.Count > _waveCounter ? waves[_waveCounter] : defaultWave;
        foreach (var waveData in currWave.waveContent)
        {
            StartCoroutine(SpawnEnemies(waveData));
        }

        _waveCounter += 1;
    }

    private IEnumerator SpawnEnemies(WaveContentData waveData)
    {
        yield return new WaitForSeconds(waveData.delayBeforeStart);
        if (waveData.gradualSpawn)
        {
            while (!GameManagement.IsDay)
            {
                for (var i = 0; i < waveData.amountToSpawn; i++)
                {
                    var pos = (new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized) * Random.Range(waveData.spawnDistance - 5, waveData.spawnDistance + 5);
                    Instantiate(waveData.enemyToSpawn, pos + transform.position, Quaternion.identity);
                }

                yield return new WaitForSeconds(waveData.intervalBetweenSpawns);
            }
        }
        else
        {
            for (var i = 0; i < waveData.amountToSpawn; i++)
            {
                var pos = (new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized) * Random.Range(waveData.spawnDistance - 5, waveData.spawnDistance + 5);
                Instantiate(waveData.enemyToSpawn, pos + transform.position, Quaternion.identity);
            }
        }
    }

    private void OnEnable()
    {
        GameManagement.onGameFinished += _DisableEnemySpawner;
    }

    private void OnDisable()
    {
        GameManagement.onGameFinished -= _DisableEnemySpawner;
    }
    
    private void _DisableEnemySpawner()
    {
        enabled = false;
    }
}
