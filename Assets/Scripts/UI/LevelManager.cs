using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject shipDestroydUI;
    public GameObject allHumansDiedUI;
    public GameObject arrivedToXOXOUI;
    public List<TaskManager> availableTasks;
    public float delay;

    private void Awake()
    {
        // Instantiate(player, transform.position, transform.rotation);
        Invoke("StartNewTask", delay);
    }

    // void Start()
    // {
    //     Cursor.visible = false;
    //     Cursor.lockState = CursorLockMode.Locked;
    // }

    // void Update()
    // {
    //     if (shipDestroydUI.activeInHierarchy)
    //     {
    //         Cursor.visible = true;
    //         Cursor.lockState = CursorLockMode.None;
    //     }
    //     else
    //     {
    //         Cursor.visible = false;
    //         Cursor.lockState = CursorLockMode.Locked;
    //     }
    // }

    private void StartNewTask()
    {
        if (availableTasks.Count > 0)
        {
            int index = Random.Range(0, availableTasks.Count);
            availableTasks[index].EnableTask();
            availableTasks.RemoveAt(index);

            if (availableTasks.Count > 0)
            {
                Invoke("StartNewTask", delay);
            }
        }
    }

    public void ShipDestroyd()
    {
        shipDestroydUI.SetActive(true);
    }

    public void AllHumansDied()
    {
        allHumansDiedUI.SetActive(true);
    }

    public void ArrivedToXOXO()
    {
        arrivedToXOXOUI.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // shipDestroydUI.SetActive(false);
        // allHumansDiedUI.SetActive(false);
        // arrivedToXOXOUI.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
