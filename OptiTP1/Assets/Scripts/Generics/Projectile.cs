using Tomi.TomiScripts;
using UnityEngine;

// Optimizacion[3] forzamos que siempre tenga rb asi no hay que hacer un check de null
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour, IPoolableObject
{
    // Optimizacion[1] guardo el valor en el prefab y no en el disparador
    [SerializeField] private float speed;
    [SerializeField] private float lifetime = 3f;

    // Optimizacion[2] guarda el rigidbody apenas spawnea la bala 
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Invoke(nameof(PoolReturn), lifetime);
    }

    public void SetupProjectile(Vector3 pos, Quaternion rot, Vector3 forwardDir, string ownerTag)
    {
        gameObject.tag = ownerTag;
        transform.SetPositionAndRotation(pos, rot);
        Fire(forwardDir);
    }

    public void Fire(Vector3 dir)
    {
        dir.y = 0;
        _rb.velocity = dir * speed;
    }

    // para usar con el shooting Script
    public void Fire(Vector3 dir, float vel)
    {
        dir.y = 0;
        _rb.velocity = dir * vel;
    }

    // private Vector3 _speed;
    //
    // public void Fire(Vector3 bulletSpeed)
    // {
    //     //Disparo de proyectil
    //     [1]_speed = bulletSpeed;
    //     [2]var rb = GetComponent<Rigidbody>();
    //     [3]if (rb != null)
    //          rb.velocity = _speed;
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("PlayerBullet"))
        {
            if (other.CompareTag("Enemy"))
            {
                // Deal Damage to enemy
                Destroy(other.gameObject); // Destruye el objeto Enemy
                GameManager.Instance.EnemyDestroyed(); // llamo al método destroyed enemies del GM ----> CONSULTAR MAXI
                
            }
        }
        else if (gameObject.CompareTag("EnemyBullet"))
        {
            if (other.CompareTag("Player"))
            {
                // Deal Damage to player
                Destroy(other.gameObject); // Destruye el Player.
            }
        }

        PoolReturn();
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void Initialization()
    {
        gameObject.SetActive(true);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void PoolReturn()
    {
        if (!gameObject.activeSelf) return;
        GameManager.Instance.ProjectilePool.ReturnToPool(this);
        CancelInvoke();
    }
}