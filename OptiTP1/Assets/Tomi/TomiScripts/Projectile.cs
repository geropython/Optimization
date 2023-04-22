using UnityEngine;

namespace Tomi.TomiScripts
{
    public class Projectile : MonoBehaviour
    {
        private Vector3 _speed;

        public void Fire(Vector3 bulletSpeed)
        {
            //Disparo de proyectil
            _speed = bulletSpeed;
            var rb = GetComponent<Rigidbody>();
            if (rb != null) rb.velocity = _speed;
        }
    }
}