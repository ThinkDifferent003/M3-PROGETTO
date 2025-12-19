using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rangeAggro;
    [SerializeField] private Transform _playerTransform;
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject _player = GameObject.FindWithTag("Player");
        if( _player != null )
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
                
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if ( _playerTransform == null )
        {
            return;
        }
        float _distancePlayer = Vector2.Distance(transform.position, _playerTransform.position);
        if ( _distancePlayer < _rangeAggro )
        {
            transform.position = Vector2.MoveTowards(transform.position, _playerTransform.position, _speed * Time.deltaTime);
            Debug.LogWarning("TI INSEGUO!");
        }
    }
}
