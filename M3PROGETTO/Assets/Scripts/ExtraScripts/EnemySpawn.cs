using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] private float _spawnTime;
    private float _nextTimeSpawn;
    private int _currentEnemy;
    // Start is called before the first frame update
    private void Awake()
    {
        _nextTimeSpawn = _spawnTime;
    }

    private void SpawnEnemy()
    {
        Vector2 _spawnPos = transform.position;
        GameObject _newEnemy = Instantiate(_enemyPrefab, _spawnPos, Quaternion.identity);
        _currentEnemy++;
    }

    // Update is called once per frame
    void Update()
    {
        _nextTimeSpawn -= Time.deltaTime;
        if (_nextTimeSpawn <= 0f )
        {
            SpawnEnemy();
            _nextTimeSpawn = _spawnTime;
        }
    }
}
