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
    public float aliensKillInterval;

    private HUDManager hudManager;
    private AlienWave currentWave;
    private int currentWaveNumber;
    private float alienAttackCountDown;
    private float nextSpawnTime;
    private bool canSpawn = true;
    private float remainingTime;
    private int humanCount;

    void Start()
    {
        hudManager = GameObject.Find("HUDManager").GetComponent<HUDManager>();
        alienAlert.SetActive(false);

        humanCount = 40;
        remainingTime = aliensKillInterval;
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

        if (alienAttackCountDown >= startAlienAttackTime)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime <= 0 && totalAliens.Length != 0)
            {
                humanCount--;
                hudManager.aliveHumansText.text = humanCount.ToString();

                hudManager.aliveHumans = humanCount;
                
                remainingTime = aliensKillInterval;
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

    void AliensKillHumans()
    {
        GameObject[] totalAliens = GameObject.FindGameObjectsWithTag("Alien");

        if (alienAttackCountDown >= startAlienAttackTime)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime <= 0)
            {
                humanCount--;
                hudManager.aliveHumans = humanCount;
                hudManager.aliveHumansText.text = humanCount.ToString();
                
                remainingTime = aliensKillInterval;
            }
        }
    }
}
