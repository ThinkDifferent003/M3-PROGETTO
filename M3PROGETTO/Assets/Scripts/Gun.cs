using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _fireRange;
    [SerializeField] private float _fireRate;
    [SerializeField] private Transform _enemy;
    [SerializeField] private float _bulletSpeed;
    private float _lastShoot;
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject enemyobj = GameObject.FindWithTag("Enemy");
        if (enemyobj != null)
        {
           _enemy = enemyobj.transform;
        }
        
    }

    private Transform CloseestEnemy()
    {
        GameObject[] _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject _target = null;
        float _minDistance = Mathf.Infinity;
        Vector3 _currentPosition = transform.position;
        foreach (GameObject _potencialTarget in _enemies)
        {
            Vector3 _directionToTarget = _potencialTarget.transform.position - _currentPosition;
            float _sqrTarget = _directionToTarget.sqrMagnitude;
            if (_sqrTarget < _minDistance)
            {
                _minDistance = _sqrTarget;
                _target = _potencialTarget;
            }
        }
        if (_target != null)
        {
            return _target.transform;
        }
        else
        {
            return null;
        }
    }
    private bool IfCanShoot()
    {
        float _shootTime = _lastShoot + _fireRate;
        if (Time.time >= _shootTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Shoot()
    {
        if (_enemy == null) return;
        _lastShoot = Time.time;
        Vector2 _spawnPosition = transform.position;
        Vector2 _targetPosition = _enemy.position;
        Vector2 _direction = (_targetPosition - _spawnPosition).normalized;
        GameObject _bullet = Instantiate(_bulletPrefab , _spawnPosition,Quaternion.identity);
        Rigidbody2D _rb = _bullet.GetComponent<Rigidbody2D>();
        _rb.velocity = _direction * _bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        _enemy = CloseestEnemy();
       if (_enemy != null && Vector2.Distance(transform.position , _enemy.position) <= _fireRange)
        {
            if (IfCanShoot())
            {
                Shoot();
            }
        }
    }
}
