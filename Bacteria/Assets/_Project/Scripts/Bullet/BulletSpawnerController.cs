using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BulletSpawnerController : MonoBehaviour
{
    private enum SpawnerType { Straight, Spin }

    [Header("Bullet Attributes")]
    [SerializeField] private GameObject _bulletObject;
    [SerializeField] private float _speed;
    [SerializeField] private float _life;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType _spawnerType;
    [SerializeField] private float _firingRate = 1.0f;

    private GameObject _spawnedBullet;
    private float _timer = 0.0f;

    void Start()
    {
       
    }


    void Update()
    {
        _timer += Time.deltaTime;
        if (_spawnerType == SpawnerType.Spin)
        {
            transform.eulerAngles = new Vector3(0.0f, 0.0f, transform.eulerAngles.z + 1.0f);
        }

        if (_timer >= _firingRate)
        {
            Fire();
            _timer = 0.0f;
        }
    }

    private void Fire()
    {
        _spawnedBullet = Instantiate(_bulletObject, transform.position, Quaternion.identity);
        _spawnedBullet.GetComponent<BulletController>().SetSpeed(_speed);
        _spawnedBullet.GetComponent<BulletController>().SetLife(_life);
        _spawnedBullet.transform.rotation = transform.rotation;
    }
}
