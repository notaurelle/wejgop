using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWASD : MonoBehaviour
{
    public float Speed;
    Rigidbody2D Rb;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float MovementX = 0;
        float MovementY = 0;

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
        Rb.velocity = movement * Speed;
    }
}

