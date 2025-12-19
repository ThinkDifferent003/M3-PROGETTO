using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerController _playerController;
    private Animator _animator;
    private LifeController _lifeController;
    private string _isMoving = "IsMoving";
    private string _xDirection = "XDirection";
    private string _yDirection = "YDirection";
    private string _isDead = "IsDead";
    private bool _dead = false;
    
    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
        _lifeController = GetComponent<LifeController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (_lifeController  != null && _lifeController._currentHealth <= 0)
        {
            if (!_dead)
            {
                _animator.SetTrigger(_isDead);
                _dead = true;
            }
        }
        Vector2 _direction = _playerController.Direction;

        bool _moving = (_direction.x != 0) || (_direction.y != 0); 
        _animator.SetBool(_isMoving, _moving );

        if (_moving)
        {
            _animator.SetFloat(_xDirection , _direction.x);
            _animator.SetFloat (_yDirection , _direction.y);

           
        }
    }
}
