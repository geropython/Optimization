using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : ManagedUpdateBehaviour
{
    private EnemyModel _enemyModel;
    private float _lastFireTime;
    private float _fireRate;
    public GameObject enemyBullet;
    public Transform shootingPoint;

    private void Awake()
    {
        _enemyModel = GetComponent<EnemyModel>();
        _fireRate = 2f;  //Hardcodeado ?¿
        
    }
    public override void UpdateMe()
    {
        _enemyModel.EnemyMove();
        ShootLogic();
    }

    private void ShootLogic()
    {
        // _lastFireTime += Time.deltaTime;
        // if(_lastFireTime >=2f)
        //     _enemyModel.PoolShoot();
        //     _lastFireTime = 0f;
        
        _lastFireTime += Time.deltaTime;
        if (_lastFireTime >= _fireRate)
        {
            _enemyModel.PoolShoot(shootingPoint);
            _lastFireTime = 0f;
        }
    }
    // private void ShootEnemy()
    // {
    //     // Shoot Logic enemyBullet ??
    // }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destruye al Enemy al colisionar con el Player.
            _enemyModel.EnemyDestroyed(); 
        }
      
    }

}
