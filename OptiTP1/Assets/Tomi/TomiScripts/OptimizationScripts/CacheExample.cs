using System;
using UnityEngine;

namespace Tomi.TomiScripts.OptimizationScripts
{
    public class CacheExample : MonoBehaviour
    {
        private Rigidbody _cachedRigidBody;

        private void Start()
        {
            _cachedRigidBody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (_cachedRigidBody != null)
            {
                //Operaciones que utilicen la variable _cachedRigidbody
            }
        }
    }
}
