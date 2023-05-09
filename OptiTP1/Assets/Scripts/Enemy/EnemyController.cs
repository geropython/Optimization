using UnityEngine;

public class EnemyController : ManagedUpdateBehaviour
{
    private const string BULLET_TAG = "EnemyBullet";
    private EnemyModel _enemyModel;
    private float _lastFireTime;
    [SerializeField] private float fireRate = 2f;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private float timeInCurrentDirection = 0f;
    [SerializeField] private float maxTimeInCurrentDirection = 1f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float timeShootEnemy = 2f;

    private void Awake()
    {
        _enemyModel = GetComponent<EnemyModel>();
    }

    public override void UpdateMe()
    {
        ShootLogic();
        NewMovement();
    }

    private void ShootLogic()
    {
        _lastFireTime += Time.deltaTime;
        if (_lastFireTime >= fireRate)
        {
            _enemyModel.PoolShoot();
            _lastFireTime = 0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destruye al Enemy al colisionar con el Player.
            _enemyModel.EnemyDestroyed();
            GameManager.Instance.CustomGameplayUpdate.RemoveFromList(this);
        }

        if (collision.gameObject.CompareTag("Wall")) ChangeDirection();
    }

    private void NewMovement()
    {
        // Mueve el tanque en la dirección actual
        transform.position += transform.forward * (speed * Time.deltaTime);

        // Si ha pasado suficiente tiempo en la dirección actual, cambia de dirección
        timeInCurrentDirection += Time.deltaTime;
        if (timeInCurrentDirection > maxTimeInCurrentDirection)
        {
            timeInCurrentDirection = 0f;
            ChangeDirection();
        }

        timeShootEnemy -= Time.deltaTime;
        if (0f >= timeShootEnemy)
            //Fire();
            timeShootEnemy = 2f;
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
}