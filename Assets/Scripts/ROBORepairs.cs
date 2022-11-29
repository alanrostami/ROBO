using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROBORepairs : MonoBehaviour
{
    public Animator animator;

    private void Update()
    {
        if (Input.GetButtonDown("Repair"))
        {
            // Play reparing animation
            animator.SetTrigger("Repair");
        }
    }
}
