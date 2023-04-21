using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterBase
{
    public float vertical { get; private set; }
    public float horizontal { get; private set; }
    public float shootHorizontal { get; private set; }
    public float shootVertical { get; private set; }
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetPlayerAttributes();
    }

    void FixedUpdate()
    {
        GetInput();
        Move();
    }

    void SetPlayerAttributes()
    {
        healthPoints = 10;
        moveSpeed = 8;
    }

    public void Move()
    {
        //gives speed based on the movespeed variable
        rb.velocity = new Vector2(horizontal, vertical).normalized * moveSpeed;
    }

    void GetInput()
    {
        // movement inputs
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //shooting inputs
        shootHorizontal = Input.GetAxisRaw("ArrowHorizontal");
        shootVertical = Input.GetAxisRaw("ArrowVertical");

        //blocks shooting in multiple directions
        if (shootHorizontal != 0) shootVertical = 0;
        if (shootVertical != 0) shootHorizontal = 0;
    }
}
