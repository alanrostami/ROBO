using UnityEngine;

public class ROBOMoves : MonoBehaviour
{
    private Rigidbody2D rgdbdy;
    private SpriteRenderer sprite;
    private Animator animator;

    private float moveX = 0.0f;
    private float moveY = 0.0f;
    public bool isFacingRight = true;
    [SerializeField] private float moveSpeed = 5.0f;

    // List of player's animation states
    private enum ROBOAnimationState {idle, moving, stop}
    // private ROBOAnimationState state = ROBOAnimationState.idle;

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

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        ROBOAnimationState state;

        if (moveX > 0.1f)
        {
            state = ROBOAnimationState.moving;
            sprite.flipX = false;
            isFacingRight = true;

            // Flip the player
            // Flip();
        }
        else if (moveX < -0.1f)
        {
            state = ROBOAnimationState.moving;
            sprite.flipX = true;
            isFacingRight = false;

            // Flip the player
            // Flip();
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

    private void Flip()
    {
        // Switch the player facing direction
        isFacingRight = !isFacingRight;

        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}
