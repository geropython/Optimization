using UnityEngine;

namespace Player
{
    public class PlayerModel : MonoBehaviour
    {
        private Rigidbody _rb;
        [SerializeField] private float speed; // velocidad del tanque
        
       
        // Optimizacion[1] sabemos que ya es Projectile asi que no hay que hacer getcomponent
        // Optimizacion[2] sabemos que el getcomponent va a ser siempre no null 
        [SerializeField] private Projectile bulletPrefab;
        [SerializeField] private Transform shootingPoint;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        // public void SpawnTank()
        // {
        //     // spawn del tanque en el punto designado desde el inspector
        //     Instantiate(tankPrefab, spawnPoint.position, Quaternion.identity);
        // }

        public void Move(Vector3 dir)
        {
            dir.y = 0;
            _rb.velocity = dir * speed;
            // Optimizado[1] para no tener que revisar los hijos del GameObject
            transform.forward = Vector3.Lerp(transform.forward, dir, 0.9f);
            // [1]suponiendo que el cañón es el primer hijo del tanque 
            //transform.GetChild(0).LookAt(transform.position + dir);
        }

        public void Shoot()
        {
            // Crea una nueva bala y establece su velocidad hacia atrás
            var bulletObject = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
            bulletObject.Fire(shootingPoint.forward);
            
            // // Obtiene una bala del objeto Pool
            // var bulletObject = projectilePool.GetObjectFromPool(shootingPoint.position, shootingPoint.rotation);
            //
            // // Verifica que se haya obtenido una bala del objeto Pool
            // if (bulletObject == null)
            // {
            //     print("No se pudo obtener una bala del objeto Pool.");
            //     return;
            // }
    
            // // Establece la velocidad de la bala hacia atrás
            // var bullet = bulletObject.GetComponent<Projectile>();
            // if (bullet != null) bullet.Fire(-shootingPoint.forward);
            
        }

        // public void Shoot()
        // {
        //     // Crea una nueva bala y establece su velocidad hacia atrás
        //     var bulletObject = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        //     [1]var bullet = bulletObject.GetComponent<Projectile>();
        //     [2]if (bullet != null) bullet.Fire(-shootingPoint.forward);
        // }

    }
}