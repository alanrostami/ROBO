using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class Mission
{
    public string missionTitle;
    public int numberOfTasks;
    public GameObject[] typeOfTasks;
    public float timeBtwTasks;

}

public class TaskSystem : MonoBehaviour
{
    public Mission[] missions;
    public Transform[] taskLocations;
    public Animator animator;
    public Text missionAnnounce;

    private Mission currentMission;
    private int currentMissionNumber;
    private float nextAnnounceTime;
    private bool announceMission = true;
    private bool announceAnimation = false;

    private void Update()
    {
        currentMission = missions[currentMissionNumber];
        AnnounceMission();
        GameObject[] totalTasks = GameObject.FindGameObjectsWithTag("Task");

        // When ROBO completes all the tasks in each mission
        if (totalTasks.Length == 0)
        {
            if (currentMissionNumber + 1 != missions.Length)
            {
                if (announceAnimation)
                {
                    missionAnnounce.text = missions[currentMissionNumber + 1].missionTitle;
                    animator.SetTrigger("MissionComplete");
                    announceAnimation = false;
                }
            }
            else
            {
                Debug.Log("End of Missions");
            }
        }
    }

    void AnnounceNextMission()
    {
        currentMissionNumber++;
        announceMission = true;
    }

    void AnnounceMission()
    {
        if (announceMission && nextAnnounceTime < Time.time)
        {
            GameObject randomTask = currentMission.typeOfTasks[Random.Range(0, currentMission.typeOfTasks.Length)];
            Transform randomLocation = taskLocations[Random.Range(0, taskLocations.Length)];
            Instantiate(randomTask, randomLocation.position, Quaternion.identity);

            currentMission.numberOfTasks--;
            nextAnnounceTime = Time.time + currentMission.timeBtwTasks;

            if (currentMission.numberOfTasks == 0)
            {
                announceMission = false;
                announceAnimation = true;
            }
        }
    }
}
