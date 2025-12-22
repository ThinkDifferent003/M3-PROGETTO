using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rangeAggro;
    [SerializeField] private Transform _playerTransform;
    private Rigidbody2D _rb;
    private Animator _animator;
    private LifeController _lifeController;
    private string _xDirection = "XDirection";
    private string _yDirection = "YDirection";
    private string _isMoving = "IsMoving";
    private string _isDead = "IsDead";
    private bool _dead = false;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _lifeController = GetComponent<LifeController>();
        _animator = GetComponent<Animator>();
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
        if (!_dead && _lifeController != null && _lifeController._currentHealth <= 0)
        {
            _dead = true;
            _rb.velocity = Vector2.zero;
            _animator.SetTrigger(_isDead);
        }
        
    }

    private void FixedUpdate()
    {
        if (_dead || _playerTransform == null)
        {
            return;
        }
        float _distancePlayer = Vector2.Distance(transform.position, _playerTransform.position);
        if (_distancePlayer < _rangeAggro)
        {
            Vector2 direction = ((Vector2)_playerTransform.position - (Vector2)transform.position).normalized;
            _rb.velocity = direction * _speed;
            _animator.SetBool(_isMoving, true);
            _animator.SetFloat(_xDirection, direction.x);
            _animator.SetFloat(_yDirection, direction.y);
            Debug.LogWarning("TI INSEGUO!");
        }
        else
        {
            _rb.velocity = Vector2.zero;
            _animator.SetBool(_isMoving , false);
        }
    }
}
