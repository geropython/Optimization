using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : ManagedUpdateBehaviour
{
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private float fireRate;
    //[SerializeField] private float projectileSpeed;
    
    private float _fireTimer;
    
    public override void UpdateMe()
    {
        if (_fireTimer <= 0)
        {
            Fire();
            _fireTimer = fireRate;
        }
        else
        {
            _fireTimer -= Time.deltaTime;
        }
    }
    
    private void Fire()
    {
       // Projectile p = projectileManager.GetFromPool();
       var p = GameManager.Instance.ProjectilePool.GetFromPool();
       p.SetupProjectile(projectileSpawnPoint.position, projectileSpawnPoint.rotation,transform.forward,"EnemyBullet");
       //p.Fire(transform.forward, projectileSpeed); //era el forward ajsjaj no s
    }
    
    
    
}
