using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyModel : MonoBehaviour
{

    public float timeInCurrentDirection = 0f;
    public float maxTimeInCurrentDirection = 1.5f;
    public float speed = 15f;
    private EnemiesKilledCounter _killCounter ;

    [SerializeField] private Transform shootingPoint;
    private const string BULLET_TAG = "EnemyBullet";
    public float timeShootEnemy = 2f;

   

    public void EnemyMove()
    {
        transform.position += transform.forward * (speed * Time.deltaTime);

        // Si ha pasado suficiente tiempo en la direcci�n actual, cambia de direcci�n
        timeInCurrentDirection += Time.deltaTime;
        if (timeInCurrentDirection > maxTimeInCurrentDirection)
        {
            timeInCurrentDirection = 0f;
            ChangeDirection();
        }
    }

    public void ChangeDirection()
    {
        // Cambia la direcci�n aleatoriamente
        int randomDirection = Random.Range(0, 4);
        switch (randomDirection)
        {
            case 0:
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                break;
            case 1:
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                break;
            case 2:
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                break;
            case 3:
                transform.rotation = Quaternion.Euler(0f, 270f, 0f);
                break;
        }
    }
    public void PoolShoot()
    {    
        print("Pedi pool");  
        var bullet = GameManager.Instance.ProjectilePool.GetFromPool();
        bullet.SetupProjectile(shootingPoint.position, shootingPoint.rotation, shootingPoint.forward, BULLET_TAG);
    }

    public void EnemyDestroyed()
    {
        // _killCounter.IncrementEnemiesKilled();
        Destroy(this); 
        
    }
}
