using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBTaskSystem
{
    public class Task
    {
        public Vector2 targetPosition;
    }

    private List<Task> taskList;

    public RBTaskSystem()
    {
        taskList = new List<Task>();
    }

    public Task AnnounceNextTask()
    {
        // If still there are tasks
        if (taskList.Count > 0)
        {
            // Give ROBO the first task
            Task task = taskList[0];
            taskList.RemoveAt(0);
            return task;
        }
        else
        {
            // Tasks are all done
            return null;
        }
    }

    public void AddTask(Task task)
    {
        taskList.Add(task);
    }
}