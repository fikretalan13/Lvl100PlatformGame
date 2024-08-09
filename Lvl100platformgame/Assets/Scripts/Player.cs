using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float playerSpeed;
    float horizontalInput;

    [Header("Jump System")]
    public float jumpForce;
    bool isGrounded;
    bool canDoubleJump;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    float groundCheckRadius = 0.3f;

    [Header("Wall Jump System")]
    [SerializeField] Transform wallCheckPos;
    public Vector2 wallCheckSize = new Vector2(.49f, .03f);
    [SerializeField] LayerMask wallLayer;
    public float wallSlideSpeed = 2;
    bool isWallSliding;
    bool isWallJumping;
    float wallJumpDirection;
    float wallJumpTime = 0.5f;
    float wallJumpTimer;
    public Vector2 wallJumpPower = new Vector2(6f, 12f);



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        canDoubleJump = false;

    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            canDoubleJump = true;
        }


        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                Jump();
            }
            else if (canDoubleJump)
            {
                Jump();
                canDoubleJump = false;
            }
            else if (isWallSliding)
            {
                WallJump();
            }
        }

        ProcessWallSlide();
        ProcessWallJump();
    }
    private void LateUpdate()
    {
        if (!isWallJumping)
        {
            Movement();
            Flip();
        }
    }

    void Flip()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    void WallJump()
    {
        isWallJumping = true;
        rb.velocity = new Vector2(wallJumpDirection * wallJumpPower.x, wallJumpPower.y);
        wallJumpTimer = 0;
        canDoubleJump = true; // Wall jump sonrası double jump'ı etkinleştirin
        Invoke("CancelWallJump", wallJumpTime + .1f);
    }



    void Movement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * playerSpeed, rb.velocity.y);
    }
    private bool WallCheck()
    {
        return Physics2D.OverlapBox(wallCheckPos.position, wallCheckSize, 0, wallLayer);
    }
    void ProcessWallSlide()
    {
        if (!isGrounded && WallCheck() && horizontalInput != 0)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -wallSlideSpeed));
        }
        else
        {
            isWallSliding = false;
        }
    }

    void ProcessWallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpDirection = -transform.localScale.x;
            wallJumpTimer = wallJumpTime;

            CancelInvoke("CancelWallJump");
        }
        else if (wallJumpTimer > 0f)
        {
            wallJumpTimer -= Time.deltaTime;
        }
    }

    void CancelWallJump()
    {
        isWallJumping = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(wallCheckPos.position, wallCheckSize);
    }
    //*****
}
