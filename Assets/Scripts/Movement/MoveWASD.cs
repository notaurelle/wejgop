using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveWASD : MonoBehaviour
{
    Rigidbody2D Rb;
    public float speed = 5f; // Default speed value
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
    }

    void Update()
    {
        float MovementX = 0;
        float MovementY = 0;
        anim.SetBool("IsWalking", false);

        if (Input.GetKey(KeyCode.W))
        {
            MovementY = 1;
            anim.SetBool("IsWalking", true);

        }
        else if (Input.GetKey(KeyCode.S))
        {
            MovementY = -1;
            anim.SetBool("IsWalking", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            MovementX = -1;
            anim.SetBool("IsWalking", true);
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MovementX = 1;
            anim.SetBool("IsWalking", true);
            spriteRenderer.flipX = false;

        }

        Vector2 movement = new Vector2(MovementX, MovementY).normalized;
        Rb.velocity = movement * speed;

   
    }

}



 


