using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public int maxHealth = 5;
    public float timeInvincible = 2.0f;

    public int CurrentHealth { get; private set; }

    private bool _isInvincible;
    private float _invincibleTimer;

    private Rigidbody2D _rigidbody2d;

    private float _horizontal;
    private float _vertical;

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

        if (_isInvincible)
        {
            _invincibleTimer -= Time.deltaTime;
            if (_invincibleTimer < 0)
                _isInvincible = false;
        }
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
    /// <param name="amount">The amount to change Ruby's health by.
    /// Use negative amounts for damage.</param>
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (_isInvincible)
            {
                return;
            }

            _isInvincible = true;
            _invincibleTimer = timeInvincible;
        }

        CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, maxHealth);
        Debug.Log($"Current health: {CurrentHealth}/{maxHealth}");
    }
}