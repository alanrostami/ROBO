using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROBOShoots : MonoBehaviour
{
    public Animator animator;

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
    }
}
