using UnityEngine;

namespace Tomi.TomiScripts
{
    public class PlayerShooting : MonoBehaviour
    {
        //Variables de disparo / proyectil.
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private float projectileSpeed;
        [SerializeField] private float shootCooldown; // Tiempo mínimo entre disparos
        [SerializeField] private Transform shootingPoint; // Punto desde donde se disparará el proyectil

        private float _timeSinceLastShot;

        private void Update()
        {
            // Si se presiona la barra espaciadora y ha pasado suficiente tiempo desde el último disparo
            if (Input.GetKeyDown(KeyCode.Space) && _timeSinceLastShot >= shootCooldown)
            {
                Shoot();
                _timeSinceLastShot = 0.0f; // Reiniciamos el temporizador
            }

            // Actualizamos el temporizador de tiempo desde el último disparo
            _timeSinceLastShot += Time.deltaTime;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void Shoot()
        {
            // Creamos el proyectil
            GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, shootingPoint.rotation);
    
            // Aplicamos la fuerza hacia atrás al proyectil
            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
            projectileRigidbody.AddForce(-transform.forward * projectileSpeed, ForceMode.Impulse);
        }
    }
}