using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    private float velocityX;
    private bool isFacingRight = true;


    public float speed = 5f;
    public float jumpForce = 16f;

    public float groundCheckRadius;
    public float wallCheckDistance;
    public float wallSlideSpeed;

    private bool isGrounded;
    private bool isTouchingWall;
    private bool isWallSliding;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public Transform wallCheck;
    public LayerMask wallLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        CheckSurroudings();
        SetFaceDirection();
        CheckIfWallSliding();
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    #region InputHandler 
    public void Move(InputAction.CallbackContext context)
    {
        velocityX = context.ReadValue<Vector2>().x;
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetTrigger("jump");
        }
    }
    public void Sit(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animator.SetBool("isSitting", true);
        }
        else if (context.canceled)
        {
            animator.SetBool("isSitting", false);
        }
    }
    public void Climb(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetTrigger("jump");
        }
    }

    #endregion

    private void ApplyMovement()
    {
        if (!isWallSliding)
        {
            rb.linearVelocityX = velocityX * speed;
        }
        else
        {
            if (rb.linearVelocityY < -wallSlideSpeed)
            {
                rb.linearVelocityY = -wallSlideSpeed;
            }
        }
    }
    private void CheckSurroudings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        isTouchingWall = Physics2D.Raycast(wallCheck.position, isFacingRight ? transform.right : -transform.right, wallCheckDistance, wallLayer);
    }

    private void SetFaceDirection()
    {
        if (velocityX > 0 && !isFacingRight)
        {
            isFacingRight = true;
            Flip();
        }
        else if (velocityX < 0 && isFacingRight)
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

    private void UpdateAnimation()
    {
        animator.SetFloat("velocityX", Mathf.Abs(velocityX));
        animator.SetBool("isGround", isGrounded);
        animator.SetBool("isWallSliding", isWallSliding);
    }
    private void CheckIfWallSliding()
    {
        if (isTouchingWall && !isGrounded && rb.linearVelocityY < 0)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);

        Gizmos.color = Color.blue;
        Vector3 direction = isFacingRight ? transform.right : -transform.right;
        Gizmos.DrawRay(wallCheck.position, direction * wallCheckDistance);
    }
}
