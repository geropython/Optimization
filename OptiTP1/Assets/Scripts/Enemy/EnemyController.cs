using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : ManagedUpdateBehaviour
{
    private EnemyModel _enemyModel;
    private float _lastFireTime;
    [SerializeField] private float _fireRate = 2f;    

    private void Awake()
    {
        _enemyModel = GetComponent<EnemyModel>();        
    }
    public override void UpdateMe()
    {
      print("Disparo enemigo");
        ShootLogic();
        _enemyModel.EnemyMove();        
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
        }
      
    }
}
