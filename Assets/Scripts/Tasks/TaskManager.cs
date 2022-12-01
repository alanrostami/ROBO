using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public float taskDeadline = 30.0f;
    public GameObject taskAnnounce;
    public Animator animator;
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
        taskSuccess = false;
        remainingTime = taskDeadline;

        hudManager.taskAnnounceText.text = "Repair the " + taskObject + " in " + taskRoom;
        taskAnnounce.SetActive(true);
        animator.SetTrigger("ActiveTask");
    }

    private void CountDown()
    {
        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0 && !taskSuccess)
        {
            currentTask = false;
            hudManager.spaceshipHealth -= taskDamage;
            hudManager.taskAnnounceText.text = "You didn't repair the " + taskObject;
            remainingTime = taskDeadline;
        }
    }

    public void DoTheTask()
    {
        if (currentTask && !taskSuccess)
        {
            taskSuccess = true;
            currentTask = false;
            hudManager.taskAnnounceText.text = taskObject + " has been repaird.";

            animator.SetTrigger("DeactiveTask");
        }
        else if (currentTask && taskSuccess)
        {
            hudManager.taskAnnounceText.text = "No repair needed here.";
        }
    }
}
