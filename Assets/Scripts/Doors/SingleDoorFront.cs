using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleDoorFront : MonoBehaviour
{
    public GameObject doorObject;
    private Animator animator;

    void Start()
    {
        animator = doorObject.GetComponent<Animator>();
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
