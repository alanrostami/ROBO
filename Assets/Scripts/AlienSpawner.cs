using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class AlienWave
{
    public string waveTitle;
    public int numberOfAliens;
    public GameObject[] typeOfAliens;
    public float spawnInterval;
}

public class AlienSpawner : MonoBehaviour
{
    public AlienWave[] alienWaves;
    public Transform[] spawnPoints;
    public GameObject alienAlert;
    public float startAlienAttackTime;

    private HUDManager hudManager;
    private AlienWave currentWave;
    private int currentWaveNumber;
    private float alienAttackCountDown;
    private float nextSpawnTime;
    private bool canSpawn = true;

    void Start()
    {
        hudManager = GameObject.Find("HUDManager").GetComponent<HUDManager>();
        alienAlert.SetActive(false);
    }

    private void Update()
    {
        alienAttackCountDown += Time.deltaTime;
        currentWave = alienWaves[currentWaveNumber];

        SpawnWave();
    
        GameObject[] totalAliens = GameObject.FindGameObjectsWithTag("Alien");

        if (totalAliens.Length == 0 && !canSpawn)
        {
            if (currentWaveNumber + 1 != alienWaves.Length)
            {
                // Add UI for Alien alerts from the ship
                SpawnNextWave();
            }
            else
            {
                Debug.Log("End of Level One");
            }
        }
    }

    void SpawnNextWave()
    {
        currentWaveNumber++;
        canSpawn = true;
    }

    void SpawnWave()
    {
        if (alienAttackCountDown >= startAlienAttackTime)
        {
            if (canSpawn && nextSpawnTime < Time.time)
            {
                GameObject randomAlien = currentWave.typeOfAliens[Random.Range(0, currentWave.typeOfAliens.Length)];
                Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                Instantiate(randomAlien, randomPoint.position, Quaternion.identity);
                currentWave.numberOfAliens--;
                nextSpawnTime = Time.time + currentWave.spawnInterval;

                alienAlert.SetActive(true);

                if (currentWave.numberOfAliens == 0)
                {
                    canSpawn = false;
                    alienAlert.SetActive(false);
                }
            }
        }
    }    
}
