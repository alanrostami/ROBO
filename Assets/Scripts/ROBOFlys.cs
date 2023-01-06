using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROBOFlys : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rgdbdy;

    private float moveY = 0.0f;
    private float moveSpeed = 5.0f;

    private void Start()
    {
        rgdbdy = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            // Play flying animation
            rgdbdy.velocity = new Vector2(0, moveY * moveSpeed);
            animator.SetTrigger("Fly");
        }
    }
}
