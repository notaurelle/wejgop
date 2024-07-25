using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrows : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float MovementX = 0;
        float MovementY = 0;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            MovementY = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            MovementY = -1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MovementX = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            MovementX = 1;
        }

        Vector2 movement = new Vector2(MovementX, MovementY).normalized;
        rb.velocity = movement * Speed;
    }
}