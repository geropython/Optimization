using UnityEngine;
using UnityEngine.Pool;

//Precomputation
//Utiliza ObjectPool, ir a waveSpawner
public class ProjectileManager : MonoBehaviour
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
            obj => obj.Initialization(),
            obj => obj.Deactivate(),
            obj => obj.Destroy(),
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
        var p = Instantiate(projectilePrefab);
        p.gameObject.SetActive(false);
        return p;
    }

    public void ResetPool()
    {
        _projectilePool.Clear();
    }
}