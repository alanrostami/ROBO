using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public LevelManager levelManager;
    public Text daysToArriveText;
    public Text spaceshipHealthText;
    public Text aliveHumansText;
    public Text taskAnnounceText;
    public Text aliensAlertText;
    public int spaceshipHealth;
    public int aliveHumans;
    public float daysToArrive;
    private bool shipDestroyd;
    private bool allHumansDied;
    private bool arrivedToXOXO;

    private void Start()
    {
        spaceshipHealth = 100;
        spaceshipHealthText.text = spaceshipHealth.ToString() + "%";

        aliveHumans = 40;
        aliveHumansText.text = aliveHumans.ToString();

        daysToArrive = 30.0f;
        daysToArriveText.text = daysToArrive.ToString("0");
    }

    private void Update()
    {
        DecreaseDays();

        spaceshipHealthText.text = spaceshipHealth.ToString() + "%";

        aliveHumansText.text = aliveHumans.ToString();

        if (spaceshipHealth <= 0 && !shipDestroyd)
        {
            shipDestroyd = true;
            levelManager.ShipDestroyd();
        }

        if (aliveHumans <= 0 && !allHumansDied)
        {
            allHumansDied = true;
            levelManager.AllHumansDied();
        }
    }

    private void DecreaseDays()
    {
        daysToArrive -= 0.05f * Time.deltaTime;
        daysToArriveText.text = daysToArrive.ToString("0");

        if (daysToArrive <= 0 && !arrivedToXOXO)
        {
            arrivedToXOXO = true;
            levelManager.ArrivedToXOXO();
        }
    }
}
