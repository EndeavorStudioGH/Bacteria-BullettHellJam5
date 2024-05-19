using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField] private int _enemyHealth;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void DamageEnemy(int damage) { 
        _enemyHealth -= damage;

        if(_enemyHealth <= 0)
        {
            EnemyDeath();
        }
    }

    private void EnemyDeath()
    {
        Destroy(gameObject);
    }
}
