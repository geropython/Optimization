using UnityEngine;

public class EnemyController : ManagedUpdateBehaviour
{
    private EnemyModel _enemyModel;
    private float _lastFireTime;
    private float _timeInCurrentDirection = 0f;
    private float _waitedToMove = 0f;
    [SerializeField] private float fireRate = 2f;
    [SerializeField] private float maxTimeInCurrentDirection = 1f;
    [SerializeField] private float maxWaitTime = 1f;
    [SerializeField] private float speed = 5f;

    private void Awake()
    {
        _enemyModel = GetComponent<EnemyModel>();
        _enemyModel.ChangeDirection();
    }

    public override void UpdateMe()
    {
        ShootLogic();
        MoveLogic();
        ChangeForwardDirection();
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
        // Destruye al Enemy al colisionar con el Player.
        if (collision.gameObject.CompareTag("Player")) _enemyModel.EnemyDestroyed();

        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Enemy"))
        {
            _enemyModel.ChangeDirection();
            _waitedToMove = 0f;
        }
    }

    private void MoveLogic()
    {
        // Mueve el tanque en la dirección actual
        _waitedToMove += Time.deltaTime;
        if (_waitedToMove > maxWaitTime) _enemyModel.EnemyMove(transform.forward * (speed * Time.deltaTime));
    }

    private void ChangeForwardDirection()
    {
        // Si ha pasado suficiente tiempo en la dirección actual, cambia de dirección
        _timeInCurrentDirection += Time.deltaTime;
        if (_timeInCurrentDirection > maxTimeInCurrentDirection)
        {
            _timeInCurrentDirection = 0f;
            _enemyModel.ChangeDirection();
            _waitedToMove = 0f;
        }
    }
}