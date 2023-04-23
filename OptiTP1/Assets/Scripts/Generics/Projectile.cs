using UnityEngine;

// Optimizacion[3] forzamos que siempre tenga rb asi no hay que hacer un check de null
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    // Optimizacion[1] guardo el valor en el prefab y no en el disparador
    [SerializeField] private float speed;

    // Optimizacion[2] guarda el rigidbody apenas spawnea la bala 
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Fire(Vector3 dir)
    {
        dir.y = 0;
        _rb.velocity = dir * speed;
    }

    // para usar con el shooting Script
    public void Fire(Vector3 dir, float vel)
    {
        dir.y = 0;
        _rb.velocity = dir * vel;
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }

    // private Vector3 _speed;
    //
    // public void Fire(Vector3 bulletSpeed)
    // {
    //     //Disparo de proyectil
    //     [1]_speed = bulletSpeed;
    //     [2]var rb = GetComponent<Rigidbody>();
    //     [3]if (rb != null)
    //          rb.velocity = _speed;
    // }
}