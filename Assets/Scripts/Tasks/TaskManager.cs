using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public float taskDeadline = 30.0f;
    private float remainingTime;
    public bool currentTask;
    private bool taskSuccess;

    void Start()
    {
        
    }

    private void Update()
    {
        if(currentTask){
            CountDown();
        }
    }

    public void EnableTask(){
        Debug.Log(gameObject.name+" task has begun...");
        currentTask = true;
        remainingTime = taskDeadline;
    }

    private void CountDown()
    {
        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0 && taskSuccess)
        {
            Debug.Log(currentTask);
            Debug.Log("Next Task");
            // if (taskSuccess)
            // {
            //     Debug.Log("Go On");
            //     Debug.Log(currentTask);
            // }
            // else if (!taskSuccess)
            // {
            //     Debug.Log("Ship damaged");
            //     Debug.Log(currentTask);
            // }
        }
        else if (remainingTime <= 0 && !taskSuccess)
        {
            remainingTime = taskDeadline;
            currentTask = false;
            Debug.Log(currentTask);
            Debug.Log("Ship damaged");
        }
    }

    public void DoTheTask()
    {        
        if (currentTask)
        {
            taskSuccess = true;
            currentTask = false;
        }
        else
        {
            Debug.Log("There is no task");
        }
    }

    private void TaskSuccess()
    {
        taskSuccess = true;
        currentTask = false;
        Debug.Log("Task Success");
    }

    private void TaskFailed()
    {
        taskSuccess = false;
        currentTask = false;
        Debug.Log("Ship damaged");
    }
}
