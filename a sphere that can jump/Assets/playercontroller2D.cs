﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller2D : MonoBehaviour
{


        Animator animator;
        Rigidbody2D rb2d;
        SpriteRenderer spriteRenderer;
        
        bool isGrounded;

        [SerializeField]
        Transform groundCheck;





    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        


    }

   

      private void FixedUpdate()  
    {
        if(Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if(Input.GetKey("d") || Input.GetKey("right"))
        { 
            rb2d.velocity = new Vector2(2, rb2d.velocity.y);
            animator.Play("player_run");
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {   
            rb2d.velocity = new Vector2(-2, rb2d.velocity.y);
            animator.Play("player_run");
            spriteRenderer.flipX = true;
        }
        else 
        {
        animator.Play("player_idle");
        rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        
        if(Input.GetKey("space") && isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 3);
            animator.Play("player_jump");
        }
        
    }

    


}
