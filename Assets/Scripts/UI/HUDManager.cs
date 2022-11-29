using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HUDManager : MonoBehaviour
{
    //This is a reference to the Text component on the HUD gameobject that will display how much time has passed since the level started
    [SerializeField] private Text daysText;
    [SerializeField] private Text spaceshipHealthText;
    [SerializeField] private Text aliveHumansText;

    private float currentSpaceshipHealth;
    private float newSpaceshipHealth = 100;
    private float daysToArrive = 300.0f;

    private void Start()
    {
        // Health.UpdateHealth -= ChangeValue;
    }

    private void Update()
    {
        DecreaseDays();
        NewHealthValue();
        // AliveHumans();
    }

    private void DecreaseDays()
    {
        daysToArrive -= Time.deltaTime;
        daysText.text = Mathf.Round(daysToArrive) + "";
        // Debug.Log(daysToArrive);

        if (currentSpaceshipHealth > 0)
        {
            // daysToArrive -= Time.deltaTime;

            // Debug.Log(daysToArrive);

            // daysText.text;
        }
    }

    private void ChangeValue(int amount)
    {

    }

    private void NewHealthValue()
    {
        if (currentSpaceshipHealth != newSpaceshipHealth)
        {
            
        }
    }
}
