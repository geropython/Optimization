using System.Collections.Generic;
using UnityEngine;

namespace Tomi.TomiScripts
{
    public class ProjectilePool : MonoBehaviour
    {
        //Ejempo de clase de MIRANDA.
        public GameObject projectilePrefab;
        public int poolSize = 10;

        private Queue<GameObject> _pooledProjectiles;

        private void Start()
        {
            _pooledProjectiles = new Queue<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                GameObject projectile = Instantiate(projectilePrefab);
                projectile.SetActive(false);
                _pooledProjectiles.Enqueue(projectile);
            }
        }
    
    
    }
}
