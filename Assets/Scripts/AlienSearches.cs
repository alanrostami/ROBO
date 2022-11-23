using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class AlienSearches : MonoBehaviour
{
    // Array of path points to move from one to another
    [SerializeField] private Transform[] pathPoints;
    [SerializeField] private float moveSpeed = 1.0f;
    
    private int pathPointIndex = 0;

    private void Start()
    {
        transform.position = pathPoints[pathPointIndex].transform.position;
    }

    private void Update()
    {
        // Move Alien
        MoveAlien();
    }

    private void MoveAlien()
    {
        if (pathPointIndex <= pathPoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, 
                pathPoints[pathPointIndex].transform.position, 
                moveSpeed * Time.deltaTime);
            
            if (transform.position == pathPoints[pathPointIndex].transform.position)
            {
                pathPointIndex += 1;
            }
        }
    }
}
