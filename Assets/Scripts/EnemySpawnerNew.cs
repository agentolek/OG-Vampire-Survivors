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
        foreach (var enemyAndAmount in currWave.waveContent)
        {
            for (var i = 0; i < enemyAndAmount.amountToSpawn; i++)
            {
                var pos = (new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized) * Random.Range(currWave.spawnDistance - 5, currWave.spawnDistance + 5);
                Instantiate(enemyAndAmount.enemyToSpawn, pos + transform.position, Quaternion.identity);
            }
        }

        _waveCounter += 1;
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
