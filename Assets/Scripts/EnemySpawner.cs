using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // --- public variables
    [SerializeField] public float spawnNumber = 20;
    [SerializeField] public float spawnCooldown = 10;
    [SerializeField] public float spawnDistance = 30;

    [SerializeField] public GameObject basicEnemy;
    
    // --- private variables
    private float _startTime;
    private float _lastUsedTime;
    private Transform _playerTransform;
    
    
    // --- private methods
    void Start()
    {
        _startTime = Time.time;
        _playerTransform = GameObject.Find("Player1").GetComponent<Transform>();
        SpawnEnemies();
    }

    void Update()
    {
        if (_lastUsedTime + spawnCooldown <= Time.time)
        {
            _lastUsedTime = Time.time;
            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < spawnNumber; i++)
        {
            Vector2 pos = (new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized) * spawnDistance;
            Vector2 playerPos = _playerTransform.position;
            Instantiate(basicEnemy, pos + playerPos, Quaternion.identity);
        }

        spawnNumber = Mathf.Floor(spawnNumber*1.1f);
    }
}
