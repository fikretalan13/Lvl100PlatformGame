using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float playerSpeed;
    public float jumpForce;

    bool isGrounded;
    bool canDoubleJump;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    float groundCheckRadius = 0.3f;

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
        }
        Movement();

    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * playerSpeed, rb.velocity.y);
    }
}
