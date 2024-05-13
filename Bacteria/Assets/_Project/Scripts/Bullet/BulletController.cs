using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float _bulletLife = 1.0f;
    [SerializeField] private float _rotation = 0.0f;
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private int _damage = 1;

    private Vector2 _spawnPoint;
    private float _timer = 0.0f;
    private GamePointController _pointController;

    void Start()
    {
        _spawnPoint = new Vector2(transform.position.x, transform.position.y);
        _pointController = GamePointController.instance;
    }

    void Update()
    {
        if (_timer > _bulletLife)
        {
            Destroy(gameObject);
        }
        else
        {
            _timer += Time.deltaTime;
            transform.position = Movement(_timer);
        }

    }

    //TODO: make target multiple or separate with enemy bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Enemy")
        {
            _pointController.PointPositive(50);
            Debug.Log("Enemy damaged");

            Destroy(gameObject);
        }
        else if(collision.tag == "Bullet")
        {
            _pointController.PointPositive(10);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        _pointController.PointPositive(5);
        Destroy(gameObject);
    }

    private Vector2 Movement(float timer)
    {
        float x = timer * _speed * transform.right.x;
        float y = timer * _speed * transform.right.y;

        return new Vector2(x + _spawnPoint.x, y + _spawnPoint.y);
    }

    public void SetSpeed(float speedValue)
    {
        _speed = speedValue;
    }

    public void SetLife(float lifeValue)
    {
        _bulletLife = lifeValue;
    }
}
