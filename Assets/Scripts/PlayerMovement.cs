using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rgdbdy;
    private SpriteRenderer sprite;
    private Animator animator;

    private float moveX = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        rgdbdy = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        // float moveY = Input.GetAxisRaw("Vertical");

        rgdbdy.velocity = new Vector2(moveX * 8.0f, rgdbdy.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rgdbdy.velocity = new Vector2(rgdbdy.velocity.x, 8.0f);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (moveX > 0f)
        {
            animator.SetBool("Moving", true);
            sprite.flipX = false;
        }
        else if (moveX < 0f)
        {
            animator.SetBool("Moving", true);
            sprite.flipX = true;
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger Enter");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Enter");
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Trigger Exit");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision Exit");
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        Debug.Log("Trigger Stay");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Collision Stay");
    }
}
