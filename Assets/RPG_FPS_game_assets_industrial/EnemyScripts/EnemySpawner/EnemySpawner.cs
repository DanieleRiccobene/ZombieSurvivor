using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int round = 1;               // Il round corrente
    public GameObject enemyPrefab;      // Il prefab del nemico da spawnare
    public Transform[] spawnPoints;     // Un array di punti di spawn dei nemici
    private int maxZombies;         // Il numero massimo di zombie da spawnare
    public float spawnDelay = 2f;       // Il ritardo tra ogni spawn dei nemici
    public int zombiesSpawned = 0;      // Contatore degli zombie spawnati
    private int zombiesLeft;            // Contatore degli zombie rimasti
    [SerializeField] public TMP_Text roundText;
    [SerializeField] public Canvas canvas;

    private void Start()
    {
        maxZombies = 10;
        zombiesLeft = maxZombies;
        StartCoroutine(StartText());
        StartCoroutine(SpawnEnemies());  
    }

    private void Update()
    {
        if (zombiesLeft == 0)
        {
            zombiesLeft = -1;
            //Debug.Log("Round " + round + " completed!");
            Invoke("StartRound", 5f);
        }
    }

    IEnumerator StartText()
    {
        canvas.gameObject.SetActive(true);
        roundText.text = "ROUND " + round.ToString();
        yield return new WaitForSeconds(3);
        canvas.gameObject.SetActive(false);
    }

    public void StartRound()
    {
        //Debug.Log("Round " + round + " started!");
        round++;
        maxZombies += 10;
        zombiesLeft = maxZombies;
        zombiesSpawned = 0;
        if (round <= 3) { StartCoroutine(StartText()); }
        StartCoroutine(SpawnEnemies());
    }

    public void reduceZombiesLeft()
    {
        zombiesLeft--;
        Debug.Log(zombiesLeft);
    }

    private IEnumerator SpawnEnemies()
    {
        if (round <= 3)
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
        else
        {
            Debug.Log("Fine !");
            yield return null;
        }

    }

    public int getRound()
    {
        return round;
    }
}