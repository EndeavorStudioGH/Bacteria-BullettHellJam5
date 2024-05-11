using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _moveSpeed = 2.0f;
    [SerializeField] private float _waitAtPoints;
    [SerializeField] private Rigidbody2D _rb;

    private int waypointIndex;
    private float waitCounter;

    void Start()
    {
        waitCounter = _waitAtPoints;

        foreach (Transform point in _waypoints)
        {
            point.SetParent(null);
        }
    }

    void Update()
    {
        Debug.Log("Current Index: "+ waypointIndex);
        Debug.Log(_waypoints[waypointIndex].position.x);

        if (Mathf.Abs(transform.position.x - _waypoints[waypointIndex].position.x) > 0.2f)
        {
            if (transform.position.x < _waypoints[waypointIndex].position.x)
            {
                _rb.velocity = new Vector2(_moveSpeed, _rb.velocity.y);
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                _rb.velocity = new Vector2(-_moveSpeed, _rb.velocity.y);
                transform.localScale = Vector3.one;
            }
        }
        else
        {
            _rb.velocity = new Vector2(0f, _rb.velocity.y);

            waitCounter -= Time.deltaTime;

            if (waitCounter <= 0)
            {
                waitCounter = _waitAtPoints;
                waypointIndex++;

                if (waypointIndex >= _waypoints.Length)
                {
                    waypointIndex = 0;
                }
            }
        }
    }

    private void Movement()
    {
       
    }
}
