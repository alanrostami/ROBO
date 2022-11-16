using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;

    public GameObject laserPrefab;

    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        ShootLaserBeams();

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        
        transform.position = transform.position + movement * moveSpeed * Time.deltaTime;
    }

    private void ShootLaserBeams()
    {
        Vector2 shootingDirection = new Vector2(Input.GetAxis("Horizontal"), 0.0f);

        shootingDirection.Normalize();

        if (Input.GetButtonDown("ShootLaser"))
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().velocity = shootingDirection * 8.0f;
            Destroy(laser, 2.0f);
        }
    }
}
