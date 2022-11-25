using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Task
{
    public string taskTitle;
    public int numberOfTasks;
    public GameObject[] typeOfTasks;
    public float taskInterval;
}

public class TaskAnnouncement : MonoBehaviour
{
    public Task[] tasks;
    public Transform[] taskLocations;

    private Task currentTask;
    private int currentTaskNumber;
    private float nextTaskTime;

    private bool nextTask = true;

    private void Update()
    {
        currentTask = tasks[currentTaskNumber];
        TaskAnnounce();
        GameObject[] totalTasks = GameObject.FindGameObjectsWithTag("Task");

        if (totalTasks.Length == 0 && !nextTask)
        {
            if (currentTaskNumber + 1 != tasks.Length)
            {
                // Add UI for Task alerts from the ship
                AnnounceNextWave();
            }
            else
            {
                Debug.Log("End of Level One");
            }
        }
    }

    void AnnounceNextWave()
    {
        currentTaskNumber++;
        nextTask = true;
    }

    void TaskAnnounce()
    {
        if (nextTask && nextTaskTime < Time.time)
        {
            GameObject randomTask = currentTask.typeOfTasks[Random.Range(0, currentTask.typeOfTasks.Length)];
            Transform randomTaskLocation = taskLocations[Random.Range(0, taskLocations.Length)];
            Instantiate(randomTask, randomTaskLocation.position, Quaternion.identity);
            currentTask.numberOfTasks--;
            nextTaskTime = Time.time + currentTask.taskInterval;

            if (currentTask.numberOfTasks == 0)
            {
                nextTask = false;
            }
        }
    }    
}
