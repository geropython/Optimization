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
        transform.forward = Vector3.Lerp(transform.forward, dir, 0.9f);
    }

    // Dispara
    public void PoolShoot()
    {
        var bullet = GameManager.Instance.ProjectilePool.GetFromPool();
        bullet.SetupProjectile(shootingPoint.position, shootingPoint.rotation, shootingPoint.forward, BULLET_TAG);
    }

    public void Respawn()
    {
    }
}