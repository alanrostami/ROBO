using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Task
{
    public GameObject taskPrefab;
    public int taskDamage;
}

public class TaskAnnouncement : MonoBehaviour
{
    public List<Task> tasks = new List<Task>();
    public List<GameObject> tasksToAnnounce = new List<GameObject>();
    public int currentTask;
    public int taskImportance;

    public Transform taskLocation;
    public int taskDeadline;
    private float taskTimer;
    private float tasksInterval;
    private float tasksTimer;

    void Start()
    {
        GenerateTasks();
    }

    void FixedUpdate()
    {
        if (tasksTimer <= 0)
        {
            // Announce a task
            if (tasksToAnnounce.Count > 0)
            {
                Instantiate(tasksToAnnounce[0], taskLocation.position, Quaternion.identity); // Announce first task in the tasks list
                tasksToAnnounce.RemoveAt(0); // And remove it
                tasksTimer = tasksInterval;
            }
            else
            {
                tasksTimer = 0; // If no tasks remain then end the tasks
            }
        }
        else
        {
            tasksTimer -= Time.fixedDeltaTime;
            taskTimer -= Time.fixedDeltaTime;
        }

    }

    public void AnnounceTask()
    {
        taskImportance = currentTask * 10;
        GenerateTasks();

        tasksInterval = taskDeadline / tasksToAnnounce.Count; // Gives a fixed time between each task
        taskTimer = taskDeadline; // Task deadline is read only
    }

    public void GenerateTasks()
    {
        List<GameObject> generateTasks = new List<GameObject>();

        while (taskImportance > 0)
        {
            int randTaskId = Random.Range(0, tasks.Count);
            int randTaskDamage = tasks[randTaskId].taskDamage;

            if (taskImportance - randTaskDamage >= 0)
            {
                generateTasks.Add(tasks[randTaskId].taskPrefab);
                taskImportance -= randTaskDamage;
            }
            else if (taskImportance <= 0)
            {
                break;
            }
        }
        tasksToAnnounce.Clear();
        tasksToAnnounce = generateTasks;
    }
}


// using UnityEngine.UI;
// using System;
// using TMPro;
// [System.Serializable]

// public class Task
// {
//     public string taskTitle;
//     public int numberOfTasks;
//     public GameObject[] typeOfTasks;
//     public float taskInterval;
// }

// public class TaskAnnouncement : MonoBehaviour
// {
//     public Task[] tasks;
//     public Transform[] taskLocations;
//     public Animator animator;
//     public TMP_Text taskTitle;

//     private Task currentTask;
//     private int currentTaskNumber;
//     private float nextTaskTime;

//     private bool nextTask = true;
//     private bool canAnnounce = false;

//     private void Update()
//     {
//         currentTask = tasks[currentTaskNumber];
//         Debug.Log(currentTask);
//         TaskAnnounce();
//         GameObject[] totalTasks = GameObject.FindGameObjectsWithTag("Task");

//         if (totalTasks.Length == 0)
//         {
//             if (currentTaskNumber + 1 != tasks.Length)
//             {
//                 if (canAnnounce)
//                 {
//                     taskTitle.text = tasks[currentTaskNumber + 1].taskTitle;
//                     animator.SetTrigger("TaskComplete");
//                     canAnnounce = false;   
//                 }
//             }
//             else
//             {
//                 Debug.Log("End of Level One");
//             }
//         }
//     }

//     void AnnounceNextTask()
//     {
//         currentTaskNumber++;
//         nextTask = true;
//     }

//     void TaskAnnounce()
//     {
//         if (nextTask && nextTaskTime < Time.time)
//         {
//             GameObject randomTask = currentTask.typeOfTasks[UnityEngine.Random.Range(0, currentTask.typeOfTasks.Length)];
//             Transform randomTaskLocation = taskLocations[UnityEngine.Random.Range(0, taskLocations.Length)];
//             Instantiate(randomTask, randomTaskLocation.position, Quaternion.identity);

//             taskTitle.text = tasks[currentTaskNumber].taskTitle;
//             animator.SetTrigger("TaskAnnounce");

//             currentTask.numberOfTasks--;
//             nextTaskTime = Time.time + currentTask.taskInterval;

//             if (currentTask.numberOfTasks == 0)
//             {
//                 nextTask = false;
//                 canAnnounce = true;
//             }
//         }
//     }    
// }
