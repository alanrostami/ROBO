using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject shipDestroydUI;
    public GameObject allHumansDiedUI;
    public GameObject arrivedToXOXOUI;
    public GameObject pauseMenu;
    public List<TaskManager> availableTasks;
    public float delay;
    public static bool isPaused;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

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
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
