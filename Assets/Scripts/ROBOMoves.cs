using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROBOMoves : MonoBehaviour
{
    private Rigidbody2D rgdbdy;
    private Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        rgdbdy = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        rgdbdy.velocity = new Vector2(moveX * 10f, moveY * 10f);        
    }
}
