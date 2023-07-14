using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;      // Il prefab del nemico da spawnare
    public Transform[] spawnPoints;     // Un array di punti di spawn dei nemici
    public int maxZombies = 20;         // Il numero massimo di zombie da spawnare
    public float spawnDelay = 2f;       // Il ritardo tra ogni spawn dei nemici

    private int zombiesSpawned = 0;     // Contatore degli zombie spawnati

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (zombiesSpawned < maxZombies)
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                if (zombiesSpawned >= maxZombies)
                    break;

                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
                zombiesSpawned++;
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }
}
