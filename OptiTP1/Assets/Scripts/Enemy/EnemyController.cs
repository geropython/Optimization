using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : ManagedUpdateBehaviour
{
    private EnemyModel _enemyModel;
    private float _lastFireTime;
    [SerializeField] private float _fireRate = 2f;    

    //------------------ENEMY NEW MOVEMENT VARIABLES -------------------------
    public float timeInCurrentDirection = 0f;
    public float maxTimeInCurrentDirection = 1f;
    public float speed = 5f;
    
    [SerializeField] private Transform shootingPoint;
    private const string BULLET_TAG = "EnemyBullet";
    public float timeShootEnemy=2f;
    private void Awake()
    {
        _enemyModel = GetComponent<EnemyModel>();        
    }
    public override void UpdateMe()
    {
      print("Disparo enemigo");
        ShootLogic();
        _enemyModel.EnemyMove();  
        NewMovement();
        //NEW ENEMY MOVEMENT UPDATE
      
    }

    private void ShootLogic()
    {
       
        print("Dispare"); 
        _lastFireTime += Time.deltaTime;
        if (_lastFireTime >= _fireRate)
        {
            _enemyModel.PoolShoot();
            _lastFireTime = 0f;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destruye al Enemy al colisionar con el Player.
            _enemyModel.EnemyDestroyed(); 
            GameManager.Instance.CustomGameplayUpdate.RemoveFromList(this);
        }
        
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("PARED");
            ChangeDirection();
        }
      
    }
    private void NewMovement()
    {
        // Mueve el tanque en la dirección actual
        transform.position += transform.forward * (speed * Time.deltaTime);

        // Si ha pasado suficiente tiempo en la dirección actual, cambia de dirección
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
        // Cambia la dirección aleatoriamente
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
        var bullet = GameManager.Instance.ProjectilePool.GetFromPool();
        bullet.SetupProjectile(shootingPoint.position, shootingPoint.rotation, shootingPoint.forward, BULLET_TAG);
    }
    
}
