using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : ManagedUpdateBehaviour
{
    private EnemyModel _enemyModel;
    private float _lastFireTime;
    private float _fireRate;
    public GameObject _BulletEnemy;

    private void Awake()
    {
        _enemyModel = GetComponent<EnemyModel>();
        
    }
    public override void UpdateMe()
    {
        _enemyModel.EnemyMove();
        ShootLogic();
    }

    private void ShootLogic()
    {
        _lastFireTime += Time.deltaTime;
        if(_lastFireTime >=2f)
            _enemyModel.PoolShoot();
            _lastFireTime = 0f;
    }
    private void ShootEnemy()
    {
        
    }

}
