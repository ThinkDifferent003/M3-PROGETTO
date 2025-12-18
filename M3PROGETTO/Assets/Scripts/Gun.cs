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
        _enemy = enemyobj.transform;
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
       if (_enemy ==  null)
        {
            GameObject enemyObj = GameObject.FindWithTag("Enemy");
            if (enemyObj != null )
            {
                _enemy = enemyObj.transform;
            }
        }
       if (_enemy != null && IfCanShoot())
        {
            Shoot();
        }
    }
}
