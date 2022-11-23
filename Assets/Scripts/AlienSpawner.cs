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

    private AlienWave currentWave;
    private int currentWaveNumber;
    private float nextSpawnTime;

    private bool canSpawn = true;

    private void Update()
    {
        currentWave = alienWaves[currentWaveNumber];
        SpawnWave();
        GameObject[] totalAliens = GameObject.FindGameObjectsWithTag("Alien");

        if (totalAliens.Length == 0 && !canSpawn)
        {
            currentWaveNumber++;
            canSpawn = true;
        }
    }

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomAlien = currentWave.typeOfAliens[Random.Range(0, currentWave.typeOfAliens.Length)];
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(randomAlien, randomPoint.position, Quaternion.identity);
            currentWave.numberOfAliens--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;

            if (currentWave.numberOfAliens == 0)
            {
                canSpawn = false;
            }
        }
    }    
}
