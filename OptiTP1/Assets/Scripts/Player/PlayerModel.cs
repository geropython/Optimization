using System;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    private const string BULLET_TAG = "PlayerBullet";
    private Rigidbody _rb;
    [SerializeField] private float speed; // velocidad del tanque
    [SerializeField] private Transform shootingPoint;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 dir)
    {
        dir.y = 0;
        _rb.velocity = dir * speed;
        // Optimizado[1] para no tener que revisar los hijos del GameObject
        transform.forward = Vector3.Lerp(transform.forward, dir, 0.9f);
        // [1]suponiendo que el cañón es el primer hijo del tanque 
        //transform.GetChild(0).LookAt(transform.position + dir);
    }

    // Dispara
    public void PoolShoot()
    {
        var bullet = GameManager.Instance.ProjectilePool.GetFromPool();
        bullet.SetupProjectile(shootingPoint.position, shootingPoint.rotation, shootingPoint.forward, BULLET_TAG);
    }
    
    //Colisión con el Enemy y muerte.

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Destruye el tanque del player, luego lo spawnea en a posición inicial. ¿ O lo spawneo al toque? ---> COnsultar a MAXI.
        }
    }
}