using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab; // prefab del enemigo
    [SerializeField] private List<Transform> spawnPoints; // lista de puntos de spawn
    [SerializeField] private float spawnInterval = 5f; // tiempo entre spawns

    private int _enemiesSpawned = 0; // contador de enemigos spawnados

    private void Start()
    {
        StartCoroutine(SpawnEnemies());   // expensive?¿ Non Alloc method?¿
    }

    private IEnumerator SpawnEnemies()
    {
        while (_enemiesSpawned < 100)
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                _enemiesSpawned++;
                if (_enemiesSpawned >= 100) break;
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    
    
    
}
