using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSlidingDoorLtR : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetTrigger("OpenDoor");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // doorIsOpen = false;
            animator.SetTrigger("CloseDoor");
        }
    }
}
