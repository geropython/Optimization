using UnityEngine;
using UnityEngine.Pool;

public class EnemyManager : MonoBehaviour
{
    private IObjectPool<EnemyModel> _enemyPool;
    [SerializeField] private EnemyModel enemyPrefab;

    public int PoolInactiveCount => _enemyPool.CountInactive;

    private void Awake()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        _enemyPool = new ObjectPool<EnemyModel>(
            InstantiateEnemy,
            obj => obj.Initialization(),
            obj => obj.Deactivate(),
            obj => obj.Destroy(),
            true,
            10,
            2);
    }

    public EnemyModel GetFromPool()
    {
        return _enemyPool.Get();
    }

    public void ReturnToPool(EnemyModel p)
    {
        _enemyPool.Release(p);
    }

    private EnemyModel InstantiateEnemy()
    {
        var p = Instantiate(enemyPrefab);
        p.gameObject.SetActive(false);
        return p;
    }

    public void ResetPool()
    {
        _enemyPool.Clear();
    }
}