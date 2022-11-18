using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject purpleAlienPrefab;

    [SerializeField]
    private float purpleAlienInterval = 5.0f;

    void Start()
    {
        StartCoroutine(spawnAlien(purpleAlienInterval, purpleAlienPrefab));
    }

    private IEnumerator spawnAlien(float interval, GameObject alien)
    {
        yield return new WaitForSeconds(interval);
        GameObject newAlien = Instantiate(alien, new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-6.0f, 6.0f), 0.0f), Quaternion.identity);
        StartCoroutine(spawnAlien(interval, alien));
    }
}
