using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public float taskDeadline = 30.0f;
    public GameObject taskAnnounce;
    private HUDManager hudManager;
    private float remainingTime;
    public int taskDamage;
    public string taskObject;
    public string taskRoom;
    public bool currentTask;
    private bool taskSuccess;

    void Start()
    {
        hudManager = GameObject.Find("HUDManager").GetComponent<HUDManager>();
        taskAnnounce.SetActive(false);
    }

    private void Update()
    {
        if (currentTask)
        {
            CountDown();
        }
    }

    public void EnableTask()
    {
        currentTask = true;
        remainingTime = taskDeadline;

        hudManager.taskAnnounceText.text = "Repaire the " + taskObject + " in " + taskRoom;
        taskAnnounce.SetActive(true);
    }

    private void CountDown()
    {
        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0 && taskSuccess)
        {
            // hudManager.taskAnnounceText.text = taskObject + " in " + taskRoom + "has been repaird.";
            taskAnnounce.SetActive(false);
        }
        else if (remainingTime <= 0 && !taskSuccess)
        {
            remainingTime = taskDeadline;
            currentTask = false;
            hudManager.spaceshipHealth -= taskDamage;
            hudManager.taskAnnounceText.text = "You didn't repaire the " + taskObject;
            // taskAnnounce.SetActive(false);
        }
    }

    public void DoTheTask()
    {        
        if (currentTask)
        {
            taskSuccess = true;
            currentTask = false;
            hudManager.taskAnnounceText.text = taskObject + "has been repaird.";
        }
        else if (!currentTask && taskSuccess)
        {
            hudManager.taskAnnounceText.text = taskObject + " works fine.";
        }
    }

    // private void TaskSuccess()
    // {
    //     taskSuccess = true;
    //     currentTask = false;
    //     Debug.Log("Task Success");
    // }

    // private void TaskFailed()
    // {
    //     taskSuccess = false;
    //     currentTask = false;
    //     Debug.Log("Ship damaged");
    // }
}
