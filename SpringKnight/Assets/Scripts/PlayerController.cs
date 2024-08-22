using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] float movespeed = 5f;
    [SerializeField] float jumpspeed = 2f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    private float horizontal;

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        jump();

        moveAnimations();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * movespeed, rb.velocity.y);
    }

    void moveAnimations()
    {
        if (horizontal != 0)
        {
            anim.SetFloat("Horizontal", horizontal);
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
        if (isGrounded())
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
        }
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}