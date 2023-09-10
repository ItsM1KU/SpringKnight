using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovements : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 5.0f;
    [SerializeField] float jumpforce = 5;
    Vector2 movement = Vector2.zero;

    [SerializeField] Transform GroundCheck;
    [SerializeField] float GroundCheckRadius;
    [SerializeField] LayerMask GroundLayer;
    bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, GroundLayer);
        float movementx = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(movementx, rb.velocity.y);
        rb.AddForce(movement * speed);
        jump();
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
    }

}
