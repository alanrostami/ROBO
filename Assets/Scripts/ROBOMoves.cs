using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROBOMoves : MonoBehaviour
{
    private Rigidbody2D rgdbdy;
    private SpriteRenderer sprite;
    private Animator animator;

    private float moveX = 0.0f;
    private float moveY = 0.0f;
    [SerializeField] private float moveSpeed = 5.0f;

    // List of player's animation states
    private enum ROBOAnimationState {idle, moving, shooting, stop}
    private ROBOAnimationState state = ROBOAnimationState.idle;

    private void Start()
    {
        rgdbdy = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        rgdbdy.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);

        // if (Input.GetButtonDown("Shoot"))
        // {
        //     Debug.Log("Shoot");
        //     state = ROBOAnimationState.shooting;
        //     animator.SetInteger("State", (int)state);
        // }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        ROBOAnimationState state;

        if (moveX > 0.1f)
        {
            state = ROBOAnimationState.moving;
            sprite.flipX = false;
        }
        else if (moveX < -0.1f)
        {
            state = ROBOAnimationState.moving;
            sprite.flipX = true;
        }
        else if (moveX > -0.1f || moveX < 0.1f)
        {
            state = ROBOAnimationState.stop;
        }
        else
        {
            state = ROBOAnimationState.idle;
        }

        animator.SetInteger("State", (int)state);
    }
}
