using UnityEngine;

public class EnemyModel : MonoBehaviour, IPoolableObject
{
    [SerializeField] private Transform shootingPoint;
    private UIManager _killCounter;
    private const string BULLET_TAG = "EnemyBullet";

    public void EnemyMove(Vector3 dir)
    {
        transform.position += dir;
    }

    public void ChangeDirection()
    {
        // Cambia la dirección aleatoriamente
        switch (Random.Range(0, 4))
        {
            case 0:
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                break;
            case 1:
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                break;
            case 2:
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                break;
            case 3:
                transform.rotation = Quaternion.Euler(0f, 270f, 0f);
                break;
        }
    }

    public void PoolShoot()
    {
        var bullet = GameManager.Instance.ProjectilePool.GetFromPool();

        bullet.SetupProjectile(shootingPoint.position, shootingPoint.rotation, shootingPoint.forward, BULLET_TAG);
    }

    public void EnemyDestroyed()
    {
        GameManager.Instance.EnemyDestroyed();
        GameManager.Instance.CustomGameplayUpdate.RemoveFromList(gameObject.GetComponent<EnemyController>());
        Destroy(gameObject);
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
        EnemyDestroyed();
    }
}