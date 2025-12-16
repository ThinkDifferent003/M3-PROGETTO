using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _horizontal;
    private float _vertical;
    private Rigidbody2D _rb;
    private Vector2 _moveDirection;
    public Vector2 Direction
        { get { return _moveDirection.normalized; } }
  
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        _moveDirection = new Vector2(_horizontal, _vertical).normalized;
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _moveDirection * (_speed * Time.deltaTime));
    }
}
