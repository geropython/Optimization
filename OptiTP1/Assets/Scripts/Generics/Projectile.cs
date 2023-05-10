using UnityEngine;

// Optimizacion[1] forzamos que siempre tenga rb asi no hay que hacer un check de null
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour, IPoolableObject
{
    [SerializeField] private float speed;
    [SerializeField] private float lifetime = 3f;
    private bool _isPlayerBullet;

    // Optimizacion[2] guarda el rigidbody apenas spawnea la bala, para no tener que calcularlo cada vez que se usa el valor
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
        // Optimizacion [3] hace el precalculo para ver si es player o enemy bullet 
        // y lo usa despues para no calcularlo siempre que activa collision
        if (ownerTag == "PlayerBullet")
        {
            _isPlayerBullet = true;
            gameObject.tag = ownerTag;
            gameObject.layer = 8;
        }

        if (ownerTag == "EnemyBullet")
        {
            _isPlayerBullet = false;
            gameObject.tag = ownerTag;
            gameObject.layer = 9;
        }

        transform.SetPositionAndRotation(pos, rot);
        Move(forwardDir);
    }

    private void Move(Vector3 dir)
    {
        dir.y = 0;
        _rb.velocity = dir * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isPlayerBullet)
        {
            if (other.CompareTag("Enemy")) other.gameObject.GetComponent<EnemyModel>().EnemyDestroyed();
        }
        else
        {
            if (other.CompareTag("Player")) other.gameObject.GetComponent<PlayerModel>().Respawn();
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