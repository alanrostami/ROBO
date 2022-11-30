using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // public GameObject player;
    public List<TaskManager> availableTasks;
    public float delay;
    private void Awake()
    {
        // Instantiate(player, transform.position, transform.rotation);
        Invoke("StartNewTask", delay);
    }

    private void StartNewTask(){
        if(availableTasks.Count > 0){
            
            int index = Random.Range(0, availableTasks.Count);
            availableTasks[index].EnableTask();
            availableTasks.RemoveAt(index);

            if(availableTasks.Count > 0){
                Invoke("StartNewTask", delay);
            }
        }
    }
}
