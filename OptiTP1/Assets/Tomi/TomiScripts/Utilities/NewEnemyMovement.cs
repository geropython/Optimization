using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyMovement : MonoBehaviour
{
    public float timeInCurrentDirection = 0f;
    public float maxTimeInCurrentDirection = 1f;
    public float speed = 5f;
    
    [SerializeField] private Transform shootingPoint;
    private const string BULLET_TAG = "EnemyBullet";
    public float timeShootEnemy=2f;
    
    void Update()
    {
        // Mueve el tanque en la direcci�n actual
        transform.position += transform.forward * (speed * Time.deltaTime);

        // Si ha pasado suficiente tiempo en la direcci�n actual, cambia de direcci�n
        timeInCurrentDirection += Time.deltaTime;
        if (timeInCurrentDirection > maxTimeInCurrentDirection)
        {
            timeInCurrentDirection = 0f;
            ChangeDirection();
        }
        timeShootEnemy -= Time.deltaTime;
        if (0f >= timeShootEnemy)
        {
            //Fire();
            timeShootEnemy = 2f;
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
    void OnCollisionEnter(Collision collision)
    {
        // Si colisiona con una pared, cambia de direcci�n
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("PUSO_PARED");
            ChangeDirection();
        }
    }
    public void PoolShoot()
    {
        var bullet = GameManager.Instance.ProjectilePool.GetFromPool();
        bullet.SetupProjectile(shootingPoint.position, shootingPoint.rotation, shootingPoint.forward, BULLET_TAG);
    }
}
