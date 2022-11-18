using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROBOShoots : MonoBehaviour
{
    public Animator animator;
    public GameObject laserBeam;
    public Transform laserPoint;

    [SerializeField] private float laserSpeed = 500.0f;

    private void Update()
    {
        if (Input.GetButtonDown("Shoot"))
        {
            ShootLaser();
        }
    }
    private void ShootLaser()
    {
        animator.SetTrigger("Shoot");
        GameObject laser = Instantiate(laserBeam, laserPoint.position, laserBeam.transform.rotation);
        
        if (GetComponent<ROBOMoves>().isFacingRight)
        {
            laser.GetComponent<Rigidbody2D>().AddForce(Vector2.right * laserSpeed);
            Destroy(laser, 1.5f);
        }
        else
        {
            laser.GetComponent<Rigidbody2D>().AddForce(Vector2.left * laserSpeed);
            Destroy(laser, 1.5f);
        }
    }
}
