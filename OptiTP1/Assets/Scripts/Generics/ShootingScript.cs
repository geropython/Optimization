using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float fireRate = 1f; // cantidad de disparos por seg.
    private float _lastFireTime; // El tiempo en el que se disparó la última bala

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _lastFireTime + 1f / fireRate) Shoot();
    }

    private void Shoot()
    {
        _lastFireTime = Time.time;

        // Crea una nueva bala y establece su velocidad hacia atrás
        var bulletObject = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        var bullet = bulletObject.GetComponent<Projectile>();
        if (bullet != null) bullet.Fire(-shootingPoint.forward, bulletSpeed);
    }
}