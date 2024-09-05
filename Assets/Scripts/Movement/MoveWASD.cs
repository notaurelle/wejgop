using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWASD : MonoBehaviour
{
  
    Rigidbody2D Rb;
    public float speed = 5f; // Default speed value
    float MovementX = 0;
    float MovementY = 0;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            MovementY = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MovementY = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            MovementX = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MovementX = 1;
        }

        Vector2 movement = new Vector2(MovementX, MovementY).normalized;
        Rb.velocity = movement * speed;

        

     
    }
}

