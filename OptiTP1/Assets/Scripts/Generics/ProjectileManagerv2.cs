using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;

public class ProjectileManagerv2 : MonoBehaviour
{
    private IObjectPool<Projectile> _projectilePool;
    [SerializeField] private Projectile projectilePrefab;

    private void Awake()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        _projectilePool = new ObjectPool<Projectile>(
            InstantiateProjectile,
            (obj) => obj.Initialization(),
            (obj) => obj.Deactivate(),
            (obj) => obj.Destroy(),
            true,
            10,
            10);
    }

    public Projectile GetFromPool()
    {
        return _projectilePool.Get();
    }

    public void ReturnToPool(Projectile p)
    {
        _projectilePool.Release(p);
    }

    private Projectile InstantiateProjectile()
    {
        return Instantiate(projectilePrefab);
    }
}