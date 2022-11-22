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
    [SerializeField] AlienWave[] alienWaves;
    private GameObject purpleAlienPrefab;

    
}
