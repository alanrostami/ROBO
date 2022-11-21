using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROBOShoots : MonoBehaviour
{
    private ROBOMoves ROBO;
    public Animator animator;
    public GameObject laserBeamRight;
    public GameObject laserBeamLeft;
    // public Transform laserPoint;
    public Transform laserPointRight;
    public Transform laserPointLeft;
    public float startShooting;

    [SerializeField] private float laserSpeed = 600.0f;

    void Start()
    {
        // Store ROBO's component to get its facing direction
        ROBO = GetComponent<ROBOMoves>();

        // Shooting delay
        startShooting = 0.3f;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Shoot"))
        {
            // Play shooting animation
            animator.SetTrigger("Shoot");

            // Wait for 0.3 seconds and then shoot laser beam
            StartCoroutine(ShootingDelay());
        }
    }

    private void ShootLaser()
    {
        // Check if ROBO is facing right to set the laser beam direction
        if (ROBO.isFacingRight)
        {
            // If facing right, shoot laser to right
            GameObject laserToRight = Instantiate(laserBeamRight, laserPointRight.position, laserBeamRight.transform.rotation);
            laserToRight.GetComponent<Rigidbody2D>().AddForce(Vector2.right * laserSpeed);
            Destroy(laserToRight, 1.5f);
        }
        else
        {
            // If facing left, shoot laser to left
            GameObject laserToLeft = Instantiate(laserBeamLeft, laserPointLeft.position, laserBeamLeft.transform.rotation);
            laserToLeft.GetComponent<Rigidbody2D>().AddForce(Vector2.left * laserSpeed);
            Destroy(laserToLeft, 1.5f);
        }
    }

    // Create a delay for shooting lasers
    private IEnumerator ShootingDelay()
    {
        yield return new WaitForSeconds(startShooting);
        ShootLaser();
    }
}
