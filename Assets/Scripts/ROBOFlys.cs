using UnityEngine;

public class ROBOFlys : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rgdbdy;

    public float flySpeed = 10.0f;
    // private float moveSpeed = 5.0f;

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
            rgdbdy.velocity = new Vector2(0, flySpeed * Time.deltaTime);
            animator.SetTrigger("Fly");
        }
    }
}
