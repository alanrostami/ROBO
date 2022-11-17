using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rigid_body;
    // public Laser laser;
    Vector2 moveDirection;

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("ShootLaser"))
        {
            // laser.Shoot();
        }

        moveDirection = new Vector2(moveX, moveY).normalized;

    }

    private void FixedUpdate()
    {
        rigid_body.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        
        Vector2 aimDirection = rigid_body.position;
    }
}
