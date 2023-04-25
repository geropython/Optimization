using System;
using UnityEngine;

namespace Tomi.TomiScripts.OptimizationScripts
{
    public class PrecomputationExample : MonoBehaviour
    {
        
        // EJEMPLO DEL PROFE
        private const int TABLE_SIZE = 360;
        private float[] _sinTable;
        private float[] _cosTable;
        private int _secPerDay;

        private void Start()
        {
            this.GenerateTables();
            _secPerDay = 60 * 60 * 24;
        }

        private void Update()
        {
            // Operaciones que utilizan las variables precalculadas:
            int secLAstWeek = 7 * _secPerDay;
            int angle = 90;
            float angleSin = _sinTable[angle];
        }

        void GenerateTables()
        {
            _sinTable = new float[TABLE_SIZE];
            _cosTable = new float[TABLE_SIZE];

            for (int i = 0; i < TABLE_SIZE; i++)
            {
                _sinTable[i] = Mathf.Sin(Mathf.Deg2Rad * i);
                _cosTable[i] = Mathf.Cos(Mathf.Deg2Rad * i);
            }
        }
    }
}
