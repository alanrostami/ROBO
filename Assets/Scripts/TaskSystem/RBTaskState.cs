using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBTaskState : MonoBehaviour
{
    private enum State
    {
        WaitingForNextTask,
        ExecutingTask,
        TaskDone,
        TaskNotDone,
    }

    private GameObject ROBO;
    private RBTaskSystem taskSystem;
    private State state;
    private float waitingTimer;

    public void Setup(GameObject ROBO, RBTaskSystem taskSystem)
    {
        this.ROBO = ROBO;
        this.taskSystem = taskSystem;
        state = State.WaitingForNextTask;
    }

    private void Update()
    {
        switch(state)
        {
            case State.WaitingForNextTask:
                // ROBO waiting for the next task
                waitingTimer -= Time.deltaTime;
                if (waitingTimer <= 0)
                {
                    float waitingTimerMax = 0.3f; // 300ms
                    waitingTimer = waitingTimerMax;
                    AnnounceNextTask();
                }
                break;
            case State.ExecutingTask:
                break;
            case State.TaskDone:
                break;
            case State.TaskNotDone:
                break;
        }
    }

    private void AnnounceNextTask()
    {
        Debug.Log("Announce Next Task");
        RBTaskSystem.Task task = taskSystem.AnnounceNextTask();

        if (task == null)
        {
            state = State.WaitingForNextTask;
        }
        else
        {
            state = State.ExecutingTask;
            ExecuteTask();
        }
    }

    private void ExecuteTask()
    {
        Debug.Log("Task is done");
    }
}
