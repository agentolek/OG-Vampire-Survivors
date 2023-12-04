using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float playerSpeed = 5f;
    // private float maxSpeed = 50f;

    private float _moveHorizontal = 0f;
    private float _moveVertical = 0f;

    private Rigidbody2D _rb2d;

    private void Start()
    {
        _rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _moveHorizontal = Input.GetAxisRaw("Horizontal");
        _moveVertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        
        Vector2 moveForce = new Vector2();
        
        moveForce += Vector2.right * (_moveHorizontal * Time.deltaTime);
        moveForce += Vector2.up * (_moveVertical * Time.deltaTime);

        moveForce = moveForce.normalized * playerSpeed;
        
        _rb2d.velocity = moveForce;
    }
}
