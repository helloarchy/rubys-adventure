using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2d;
    private float _horizontal;
    private float _vertical;

    public float moveSpeed = 3.0f;
    public int maxHealth = 5;
    
    public int CurrentHealth { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        CurrentHealth = maxHealth;
    }

    // Update is called once per frame
    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }

    // FixedUpdate is for physics
    private void FixedUpdate()
    {
        var position = _rigidbody2d.position;
        position.x += moveSpeed * _horizontal * Time.deltaTime;
        position.y += moveSpeed * _vertical * Time.deltaTime;

        _rigidbody2d.MovePosition(position);
    }
    
    /// <summary>
    /// Set Ruby's health
    /// </summary>
    /// <param name="amount">The amount to increase Ruby's health</param>
    public void ChangeHealth(int amount)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, maxHealth);
        Debug.Log($"Current health: {CurrentHealth}/{maxHealth}");
    }
}