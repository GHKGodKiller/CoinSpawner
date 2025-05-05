using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;

    [Header("Deteccion de tierra")]
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    private Rigidbody2D myrigidbody2D;
    private bool isGrounded;
    private bool doubleJump;
    private Animator animator;

    private void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate() 
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }


    private void Update()
    {
        if(isGrounded)
        {
            doubleJump = false;
        }

        animator.SetBool("Grounded", isGrounded);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myrigidbody2D.velocity = new Vector2 (myrigidbody2D.velocity.x, jumpHeight);
        }

        if(Input.GetKeyDown(KeyCode.Space) && !isGrounded && !doubleJump) 
        {
            myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, jumpHeight);

            doubleJump = true;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            myrigidbody2D.velocity = new Vector2(-moveSpeed, myrigidbody2D.velocity.y);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            myrigidbody2D.velocity = new Vector2(moveSpeed, myrigidbody2D.velocity.y);
        }

        animator.SetFloat("Speed", Mathf.Abs(myrigidbody2D.velocity.x));

        if(myrigidbody2D.velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        else if(myrigidbody2D.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
