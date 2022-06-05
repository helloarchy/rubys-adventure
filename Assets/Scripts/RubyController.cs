using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2d;
    private float _horizontal;
    private float _vertical;
    private const float MovementUnits = 3.0f;

    // Start is called before the first frame update
    private void Start()
    {
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 10;
        _rigidbody2d = GetComponent<Rigidbody2D>();
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
        position.x += MovementUnits * _horizontal * Time.deltaTime;
        position.y += MovementUnits * _vertical * Time.deltaTime;

        _rigidbody2d.MovePosition(position);
    }
}