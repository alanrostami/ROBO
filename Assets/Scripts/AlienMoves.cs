using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMoves : MonoBehaviour
{
    // public Transform[] pathPoints;
    // public float alienSpeed;
    // public Transform pathPoint;
    // private int nearestPoint;
    // private int pathPointIndex = 0;

    private void Start()
    {
        // pathPoint = GameObject.FindGameObjectWithTag("AlienPathPoint").transform;

        // Find the nearest point to the Alien
        // nearestPoint = 0;
        // transform.position = pathPoints[pathPointIndex].transform.position;
    }

    private void Update()
    {
        // Move Alien
        // MoveAlien();
    }

    private void MoveAlien()
    {
        // if (pathPointIndex <= pathPoints.Length - 1)
        // {
        //     transform.position = Vector2.MoveTowards(transform.position, 
        //         pathPoints[pathPointIndex].transform.position, 
        //         alienSpeed * Time.deltaTime);
            
        //     if (transform.position == pathPoints[pathPointIndex].transform.position)
        //     {
        //         pathPointIndex += 1;
        //     }
        // }
    }

    // void Update()
    // {
    //     transform.position = Vector2.MoveTowards(transform.position, pathPoint.position, alienSpeed * Time.deltaTime);

    //     if (Vector2.Distance(transform.position, pathPoints[nearestPoint].position) < 0.2f)
    //     {

    //     }
    // }
}
