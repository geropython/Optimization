using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    [SerializeField] private float timeInCurrentDirection = 0f;
    [SerializeField] private float maxTimeInCurrentDirection = 1.5f;
    [SerializeField] private float speed = 15f;
    [SerializeField] private Transform shootingPoint;
    private EnemiesKilledCounter _killCounter;
    private const string BULLET_TAG = "EnemyBullet";

    public void EnemyMove()
    {
        transform.position += transform.forward * (speed * Time.deltaTime);

        // Si ha pasado suficiente tiempo en la direcci�n actual, cambia de direcci�n
        timeInCurrentDirection += Time.deltaTime;
        if (timeInCurrentDirection > maxTimeInCurrentDirection)
        {
            timeInCurrentDirection = 0f;
            ChangeDirection();
        }
    }

    public void ChangeDirection()
    {
        // Cambia la direcci�n aleatoriamente
        var randomDirection = Random.Range(0, 4);
        switch (randomDirection)
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
        // _killCounter.IncrementEnemiesKilled();  --> FOR UI 
        Destroy(gameObject);
    }
}