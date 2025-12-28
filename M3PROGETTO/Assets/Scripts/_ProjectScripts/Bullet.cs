using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private int _damage;
    [SerializeField] private float _autoDestroy;
    private Vector2 _direction;

    public void Initialize(Vector2 _travelDirection , float _travelSpeed) 
    {
       _direction = _travelDirection.normalized;
       _bulletSpeed = _travelSpeed;
       Destroy(gameObject,_autoDestroy);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")||other.CompareTag("Obstacle"))
        {
            LifeController _health = other.GetComponent<LifeController>();
            if (_health != null)
            {
                _health.TakeDamage(_damage);
            }
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        transform.Translate(_direction *  _bulletSpeed * Time.deltaTime);
    }

}




    