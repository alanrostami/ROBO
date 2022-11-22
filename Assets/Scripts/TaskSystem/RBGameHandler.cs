using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBGameHandler : MonoBehaviour
{
    private void Start()
    {
        RBTaskSystem taskSystem = new RBTaskSystem();

        Debug.Log(taskSystem.AnnounceNextTask());

        RBTaskSystem.Task task = new RBTaskSystem.Task();
        taskSystem.AddTask(task);

        Debug.Log(taskSystem.AnnounceNextTask());
        Debug.Log(taskSystem.AnnounceNextTask());
    }
}