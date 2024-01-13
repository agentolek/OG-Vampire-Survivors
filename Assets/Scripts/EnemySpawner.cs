using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // --- public variables
    [SerializeField] public float spawnNumber = 20;
    [SerializeField] public float spawnCooldown = 10;
    [SerializeField] public float spawnDistance = 30;
    [SerializeField] public int advancedEnemyTime = 60;


    [SerializeField] public GameObject basicEnemy;
    [SerializeField] public GameObject advancedEnemy;
    
    // --- private variables
    private float _lastUsedTime;
    private Transform _playerTransform;
    private Timer _timer;
    private GameObject _currentEnemy;
    
    
    // --- private methods
    void Start()
    {
        _playerTransform = GameObject.Find("Player1").GetComponent<Transform>();
        _timer = GameObject.Find("TimerText").GetComponent<Timer>();
        _currentEnemy = basicEnemy;
        SpawnEnemies();
    }

    void Update()
    {
        if (_timer.TotalTime >= advancedEnemyTime)
        {
            _currentEnemy = advancedEnemy;
        }
        if (_lastUsedTime + spawnCooldown <= Time.time)
        {
            _lastUsedTime = Time.time;
            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        for (var i = 0; i < spawnNumber; i++)
        {
            var pos = (new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized) * Random.Range(spawnDistance-5, spawnDistance+5);
            Vector2 playerPos = _playerTransform.position;
            Instantiate(_currentEnemy, pos + playerPos, Quaternion.identity);
        }

        spawnNumber = Mathf.Floor(spawnNumber*1.1f);
    }
}
