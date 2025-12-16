using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerController _playerController;
    private Animator _animator;
    private string _isMoving = "IsMoving";
    private string _xDirection = "XDirection";
    private string _yDirection = "YDirection";
    // Start is called before the first frame update
    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
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
