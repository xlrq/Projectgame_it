using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement_right : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
   
    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForse = 14f;

    private enum movementState { idle, running, jumping }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite= GetComponent<SpriteRenderer>();
        coll= GetComponent<BoxCollider2D>();
    }

    
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForse);
        }

        updateAnimationState(); 
    }

    private void updateAnimationState()
    {
        movementState state;

        if (dirX > 0f)
        {
            state = movementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = movementState.running;
            sprite.flipX= true;
        }
        else
        {
            state = movementState.idle;
        }

        if (!isGrounded())
        {
            state= movementState.jumping;
        }

        anim.SetInteger("state", (int) state);
    }

    private bool isGrounded()
    {
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
