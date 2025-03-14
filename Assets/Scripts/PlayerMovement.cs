using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    private float velocityX;
    private float speed = 5f;
    private float jumpForce = 10f;

    private bool isFacingRight = true;
    private bool isGrounded;

    public Transform groundCheck;
    public LayerMask groundLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        rb.linearVelocityX = velocityX * speed;
        SetFaceDirection(velocityX);

        animator.SetFloat("velocityX", Mathf.Abs(velocityX));
        animator.SetBool("isGround", isGrounded);
    }

    public void Move(InputAction.CallbackContext context)
    {
        velocityX = context.ReadValue<Vector2>().x;
    }

    private void SetFaceDirection(float moveInput)
    {
        if (moveInput > 0 && !isFacingRight)
        {
            isFacingRight = true;
            Flip();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            isFacingRight = false;
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x = Mathf.Sign(velocityX) * Mathf.Abs(localScale.x);
        transform.localScale = localScale;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetTrigger("jump");
        }
 
    }
}
