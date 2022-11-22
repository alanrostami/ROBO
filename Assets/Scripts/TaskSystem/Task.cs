using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Task", menuName = "Task for ROBO")]
public class Task : ScriptableObject
{
    public string taskTitle;
    public string taskDescription;
    public Transform taskPosition;
    public GameObject taskObject;
    public float timeToComplete;
    public bool taskIsDone;
}
