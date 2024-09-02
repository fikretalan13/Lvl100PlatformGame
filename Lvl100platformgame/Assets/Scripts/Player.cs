using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    public Rigidbody2D rb;
    public float playerSpeed;
    float horizontalInput;
    
    public Animator anim;

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

    [Header("Others")]
    public bool isGravitySkillsTaken;
    int pressCount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
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
                AudioManager.instance.PlaySound(0);
            }
            else if (canDoubleJump)
            {
                Jump();
                canDoubleJump = false;
                AudioManager.instance.PlaySound(0);
            }
            else if (isWallSliding)
            {
                WallJump();
                AudioManager.instance.PlaySound(0);
            }
        }

        ProcessWallSlide();
        ProcessWallJump();


        if (Input.GetKeyDown(KeyCode.G) && isGravitySkillsTaken)
        {
            pressCount++;
            GravityZero();

        }

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

    void GravityZero()
    {
        if (pressCount % 2 == 1)
        {
            rb.gravityScale = 0;
        }
        else if (pressCount % 2 == 0)
        {
            rb.gravityScale = 3;
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
