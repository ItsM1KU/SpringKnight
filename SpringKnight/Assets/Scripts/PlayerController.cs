using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] float movespeed = 5f;
    [SerializeField] float jumpspeed = 2f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] AudioSource jumpaudio;

    private float horizontal;
    private Vector3 startingPosition;


    private void Start()
    {
        startingPosition = transform.position;
    }
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
            jumpaudio.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
        }

        if(Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0)
        {
            //jumpaudio.Play();
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fireball")
        {
            transform.position = startingPosition;
        }
    }
}