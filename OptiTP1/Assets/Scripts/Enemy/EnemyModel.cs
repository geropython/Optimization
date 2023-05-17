using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyModel : MonoBehaviour, IPoolableObject
{
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private LayerMask obstacleMask;
    private UIManager _killCounter;
    private const string BULLET_TAG = "EnemyBullet";
    private const float RAY_DISTANCE = 1.3f;
    private RaycastHit[] _resultBuffer = new RaycastHit[2];

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

        ConfirmForward();
    }

    public void ConfirmForward()
    {//Non Alloc API recomendacion cambiarlo por otro tipo de NonAlloc
        Array.Clear(_resultBuffer, 0, _resultBuffer.Length);
        if (Physics.RaycastNonAlloc(shootingPoint.position, shootingPoint.forward, _resultBuffer, RAY_DISTANCE,
                obstacleMask) <=
            0) return;
        foreach (var hit in _resultBuffer)
            if (hit.collider.CompareTag("Wall") || hit.collider.CompareTag("Obstacles"))
            {
                ChangeDirection();
                Logging.Log("confirm");
                return;
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        var direction = shootingPoint.transform.TransformDirection(Vector3.forward) * RAY_DISTANCE;
        Gizmos.DrawRay(shootingPoint.position, direction);
    }
}