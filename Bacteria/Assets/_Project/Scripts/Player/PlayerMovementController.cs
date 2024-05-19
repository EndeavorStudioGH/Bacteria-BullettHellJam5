using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerMovementController : MonoBehaviour
{

    private Vector2 _moveDirection;
    public Transform shotPosition;

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

        if (Player.instance.rb.velocity.x < 0)
        {
            //Debug.LogWarning("RIGHT");
            transform.localScale = new Vector3(-1f, 1f, 1f);
            shotPosition.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        else if (Player.instance.rb.velocity.x > 0)
        {
            //Debug.LogWarning("LEFT");
            transform.localScale = Vector3.one;
            shotPosition.rotation = new Quaternion(0f, 0f, 180f, 0f);
        }
        else if (Player.instance.rb.velocity.y < 0)
        {
            //Debug.LogWarning("UP");

            shotPosition.rotation = new Quaternion(0f, 0f, 180f, 180f);
        }
        else if (Player.instance.rb.velocity.y > 0)
        {
            //Debug.LogWarning("DOWN");
            shotPosition.rotation = new Quaternion(0f, 0f, 180f, -180f);
        }
    }
}
