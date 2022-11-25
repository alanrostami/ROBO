using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskInteraction : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetButtonDown("Repair") && collision.tag == "Task")
        {
            Destroy(collision.gameObject);
        }
    }
}
