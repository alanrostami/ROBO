using UnityEngine;

public class AlienLogic : MonoBehaviour
{
    public GameObject[] alienSpawnPoints;

    public void SpawnAlien(GameObject alien)
    {
        GameObject spawnPoint = GetRandomSpawnPoint();
        alien.transform.position = spawnPoint.transform.position;
    }

    GameObject GetRandomSpawnPoint()
    {
        return alienSpawnPoints[Random.Range(0, alienSpawnPoints.Length)];
    }
}
