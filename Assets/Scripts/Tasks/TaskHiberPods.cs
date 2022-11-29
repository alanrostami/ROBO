using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskHiberPods : MonoBehaviour
{
    public bool taskIsDone = false;
    // private float totalTime = 300.0f;
    private float taskDeadline = 30.0f;

    private void Update()
    {
        CountDown();
        TaskFailed();
    }

    private void CountDown()
    {
        taskDeadline -= Time.deltaTime;
    }

    public void DoTheTask()
    {        
        if (!taskIsDone)
        {
            taskIsDone = true;
            Debug.Log("Task is done");
        }
    }

    private void TaskFailed()
    {
        if (taskDeadline <= 0 && !taskIsDone)
        {
            Debug.Log("Ship damaged");
            taskDeadline = 30.0f;
        }
    }
}
