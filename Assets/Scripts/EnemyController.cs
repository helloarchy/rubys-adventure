using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3.0f;
    public bool vertical;
    public float changeTime = 3.0f;
    public int damageAmount = -1;
    
    private Rigidbody2D _rigidbody2D;
    private float _timer;
    private int _direction = 1;

    private Animator _animator;

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _timer = changeTime;
        
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer < 0)
        {
            _direction = -_direction;
            _timer = changeTime;
        }
    }

    private void FixedUpdate()
    {
        var position = _rigidbody2D.position;

        if (vertical)
        {
            position.y += Time.deltaTime * speed * _direction;
            
            _animator.SetFloat("Move X", 0);
            _animator.SetFloat("Move Y", _direction);
        }
        else
        {
            position.x += Time.deltaTime * speed * _direction;
            
            _animator.SetFloat("Move X", _direction);
            _animator.SetFloat("Move Y", 0);
        }

        _rigidbody2D.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(damageAmount);
        }
    }
}