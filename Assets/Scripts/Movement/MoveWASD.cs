using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveWASD : MonoBehaviour
{
    PlayerInput playerInput; 
    Rigidbody2D Rb;
    // public float speed = 5f; // Default speed value
    private Animator anim;
    bool isWalking = false; // bool for walking
    float horizontal; // moving left right
    float vertical; // moving up down 

    //flip direction
    SpriteRenderer spriteRenderer;
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        float MovementX = 0;
        float MovementY = 0;
        anim.SetBool("IsWalking", false);

        if (playerInput.northButton)
        {
            MovementY = 1;
            anim.SetBool("IsWalking", true);
            // playerInput.northButton = false;

        }
        else if (playerInput.southButton)
        {
            MovementY = -1;
            anim.SetBool("IsWalking", true);
           //  playerInput.southButton = false;
        }

        if (playerInput.westButton)
        {
            MovementX = -1;
            anim.SetBool("IsWalking", true);
            spriteRenderer.flipX = true;
            // playerInput.westButton = false;
        }
        else if (playerInput.eastButton)
        {
            MovementX = 1;
            anim.SetBool("IsWalking", true);
            spriteRenderer.flipX = false;
           // playerInput.eastButton = false;

        }

        Vector2 movement = new Vector2(MovementX, MovementY).normalized;
        //Rb.velocity = movement * speed;

   
    }

}



 


