using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    private Vector2 _moveDirection;

    void Start()
    {

    }

    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        _moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        Player.instance.rb.velocity = new Vector2(_moveDirection.x * Player.instance.maxSpeed, _moveDirection.y * Player.instance.maxSpeed);
    }
}
