using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Cambiar para utilizar ObjectPool
public class EnemySpawner : CustomUpdateManager
{
    [SerializeField] private ManagedUpdateBehaviour enemyPrefab; // prefab del enemigo
    [SerializeField] private List<Transform> spawnPoints; // lista de puntos de spawn
    [SerializeField] private float spawnInterval = 5f; // tiempo entre spawns
    private int _enemiesSpawned = 0; // contador de enemigos spawneados

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (_enemiesSpawned < 100)
        {
            foreach (var spawnPoint in spawnPoints)
            {
                var go = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                GameManager.Instance.CustomGameplayUpdate.AddToList(go);
                _enemiesSpawned++;
                if (_enemiesSpawned >= 100) break;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Agregar EnemyManager como pool para que no spawneen infinitos a la vez
}