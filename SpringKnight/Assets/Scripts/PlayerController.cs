using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D player;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    public float jumpStartTime;
    private float jumpTime;
    private bool isJumping;

    public Transform wallCheck;
    public LayerMask wallLayer;
    private bool isWallSliding;
    private float wallslidespeed = 0.2f;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            isJumping = true;
            jumpTime = jumpStartTime;
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }

        if(Input.GetButton("Jump") && isTouchingGround)
        {
            if (jumpTime > 0)
            {
                player.velocity = new Vector2(player.velocity.x, jumpSpeed);
                jumpTime -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

        wallSlide();
    }

    private bool isWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void wallSlide()
    {
        if( isWalled() && !isTouchingGround)
        {
            isWallSliding = true;
            player.velocity = new Vector2(player.velocity.x, Mathf.Clamp(player.velocity.y, -wallslidespeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }
        

        
}