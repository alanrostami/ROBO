// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// [System.Serializable]
// public class Task
// {
//     public GameObject taskPrefab;
//     public int taskDamage;
// }

// public class TaskAnnouncement : MonoBehaviour
// {
//     public List<Task> tasks = new List<Task>();
//     public List<GameObject> tasksToAnnounce = new List<GameObject>();
//     public int currentMission;
//     public int missionImportance;

//     public Transform[] taskLocations;
//     public int missionDeadline;
//     private float missionTimer;
//     private float timeBetweenTasks;
//     private float taskTimer;

//     void Start()
//     {
//         AnnounceMission();
//     }

//     void FixedUpdate()
//     {
//         if (taskTimer <= 0)
//         {
//             // Announce a task
//             if (tasksToAnnounce.Count > 0)
//             {
//                 Instantiate(tasksToAnnounce[0], taskLocations[Random.Range(0, taskLocations.Length)].position, Quaternion.identity); // Announce first task in the tasks list
//                 tasksToAnnounce.RemoveAt(0);
//                 taskTimer = timeBetweenTasks;
//             }
//             else
//             {
//                 taskTimer = 0; // If no tasks remain then end the tasks
//             }
//         }
//         else
//         {
//             taskTimer -= Time.fixedDeltaTime;
//             missionTimer -= Time.fixedDeltaTime;
//         }

//     }

//     public void AnnounceMission()
//     {
//         missionImportance = currentMission * 10;
//         AnnounceTask();

//         timeBetweenTasks = missionDeadline / tasksToAnnounce.Count; // Gives a fixed time between each task
//         missionTimer = missionDeadline; // Task deadline is read only
//     }

//     public void AnnounceTask()
//     {
//         List<GameObject> generateTasks = new List<GameObject>();

//         while (missionImportance > 0)
//         {
//             int randTaskId = Random.Range(0, tasks.Count);
//             int randTaskDamage = tasks[randTaskId].taskDamage;

//             if (missionImportance - randTaskDamage >= 0)
//             {
//                 generateTasks.Add(tasks[randTaskId].taskPrefab);
//                 missionImportance -= randTaskDamage;
//             }
//             else if (missionImportance <= 0)
//             {
//                 break;
//             }
//         }
//         tasksToAnnounce.Clear();
//         tasksToAnnounce = generateTasks;
//     }
// }


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
