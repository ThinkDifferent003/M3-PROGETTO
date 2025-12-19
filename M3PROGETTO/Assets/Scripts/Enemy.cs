using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
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
        _animator = GetComponent<Animator>();
        _lifeController = GetComponent<LifeController>();
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

    private void Update()
    {
        if (!_dead && _lifeController != null && _lifeController._currentHealth <= 0)
        {
            _dead = true;
            _rb.velocity = Vector2.zero;
            _animator.SetTrigger(_isDead);
        }    
    }


    void FixedUpdate()
        {
            if (_dead || _playerTransform == null) return;

            Vector2 _direction = ((Vector2)_playerTransform.position - (Vector2)transform.position).normalized;
            _rb.velocity = _direction * _speed;
            
            bool _moving = _rb.velocity.x != 0 || _rb.velocity.y != 0;
        _animator.SetBool(_isMoving , _moving);
          if (_moving)
           {
              _animator.SetFloat(_xDirection , _direction.x);
              _animator.SetFloat(_yDirection , _direction.y);
           }
        }   
    
}

