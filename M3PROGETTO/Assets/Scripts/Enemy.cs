using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _playerTransform;
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject _player = GameObject.FindWithTag("Player");
        if (_player != null)
        {
            _playerTransform = _player.transform;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LifeController _playerLife = other.GetComponent<LifeController>();
            if (_playerLife != null)
            {
                {
                    _playerLife.TakeDamage(5);
                }
                Destroy(gameObject);
            }
        }
    }

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, _playerTransform.position, _speed * Time.deltaTime);
        }
    
}

