using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float moveSpeed = 12f;
    bool isFacingRight = false;
    float jumpPower = 9f;
    bool isGrounded = false;
    int jumpsLeft;
    public int maxJumps = 2;
    public Vector3 respawnPoint;
    public GameObject fallDetector;


    Rigidbody2D rb;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        FlipSprite();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
            jumpsLeft = maxJumps;
        }


        if (Input.GetButtonDown("Jump") && jumpsLeft > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpsLeft -= 1;
            animator.SetBool("isJumping", !isGrounded);
        }

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);


    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);

        if (GameManager.instance.myState != GameManager.State.playing) return;
        Vector2 v = rb.velocity;
        v.x = Input.GetAxis("Horizontal") * moveSpeed;
        rb.velocity = v;
    }

    void FlipSprite()
    {
        if (isFacingRight && horizontalInput > 0f || !isFacingRight && horizontalInput < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);

        if (collision.tag == "fallDetector")
        {
            transform.position = respawnPoint;
        }

        if (collision.gameObject.tag == "collectable")
        {
            Destroy(collision.gameObject);
            GameManager.instance.IncreaseScore(10);

        }

    }
}




