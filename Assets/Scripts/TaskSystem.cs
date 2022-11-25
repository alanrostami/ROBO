using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private Mission currentMission;
    private int currentMissionNumber;
    private float nextAnnounceTime;
    private bool canAnnounce = true;

    private void Update()
    {
        currentMission = missions[currentMissionNumber];
        AnnounceMission();
        GameObject[] totalTasks = GameObject.FindGameObjectsWithTag("Task");

        // When ROBO completes all the tasks in each mission
        if (totalTasks.Length == 0 && !canAnnounce && currentMissionNumber + 1 != missions.Length)
        {
            currentMissionNumber++;
            canAnnounce = true;
        }
    }

    void AnnounceMission()
    {
        if (canAnnounce && nextAnnounceTime < Time.time)
        {
            GameObject randomTask = currentMission.typeOfTasks[Random.Range(0, currentMission.typeOfTasks.Length)];
            Transform randomLocation = taskLocations[Random.Range(0, taskLocations.Length)];
            Instantiate(randomTask, randomLocation.position, Quaternion.identity);

            currentMission.numberOfTasks--;
            nextAnnounceTime = Time.time + currentMission.timeBtwTasks;

            if (currentMission.numberOfTasks == 0)
            {
                canAnnounce = false;
            }
        }
    }
}
