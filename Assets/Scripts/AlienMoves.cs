using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMoves : MonoBehaviour
{
    public float alienSpeed;
    private Transform targetPoint;

    void Start()
    {
        targetPoint = GameObject.FindGameObjectWithTag("AlienTargetPoint").transform;

    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, targetPoint.position, alienSpeed * Time.deltaTime);
    }
}
