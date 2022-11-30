using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HUDManager : MonoBehaviour
{
    //This is a reference to the Text component on the HUD gameobject that will display how much time has passed since the level started
    public Text daysToArriveText;
    public Text spaceshipHealthText;
    public Text aliveHumansText;
    public Text taskAnnounceText;
    public Text aliensAlertText;
    public int spaceshipHealth;
    public int aliveHumans;
    public float daysToArrive;

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
    }

    private void DecreaseDays()
    {
        daysToArrive -= 0.01f * Time.deltaTime;
        daysToArriveText.text = daysToArrive.ToString("0");
    }
}
