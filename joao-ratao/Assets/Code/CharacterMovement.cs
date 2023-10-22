using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    private bool isFacingRight = true;
    public bool isCrounching = false;

    /*private bool isWallSliding;
    [SerializeField] private float wallSlidingSpeed = 2f;
    private bool isWallJumping;
    private float wallJumpingDirection;
    [SerializeField] private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    [SerializeField] private float wallJumpingDuration = 0.4f;
    [SerializeField] private Vector2 wallJumpingPower = new Vector2(5f, 10f);*/

    [SerializeField] private Vector2 KBPower = new Vector2(2f, 4f);
    public float KBCounter;
    public float KBTotalTime;
    public bool KnockFromRight;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    [SerializeField] private Animator animator;


    private void Update()
    {
        if (!gameObject.GetComponent<CharacterHealth>().isDead)
        {
            horizontal = Input.GetAxis("Horizontal");

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            if (Input.GetButtonDown("Crouch"))
            {
                isCrounching = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                isCrounching = false;
            }

            /*WallSlide();
            WallJump();

            if (!isWallJumping)
            {
                Flip();
            }*/
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if (!gameObject.GetComponent<CharacterHealth>().isDead)
        {
            /*if (!isWallJumping)
            {
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            }*/

            if (KBCounter <= 0)
            {
                rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            }
            else
            {
                if (KnockFromRight == true)
                {
                    rb.velocity = new Vector2(-KBPower.x, KBPower.y);
                }

                if (KnockFromRight == false)
                {
                    rb.velocity = new Vector2(KBPower.x, KBPower.y);
                }

                KBCounter -= Time.deltaTime;
            }
            animator.SetFloat("Speed", Mathf.Abs(horizontal*speed));
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    /*private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if (IsWalled() && !IsGrounded() && horizontal != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }*/

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}