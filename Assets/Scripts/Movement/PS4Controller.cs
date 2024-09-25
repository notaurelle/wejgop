//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem;

//// public class PS4Controller : MonoBehaviour

//{
//    public float speed;
//    private Rigidbody2D rb;
//    private PlayerInputActions inputActions;
//    private Vector2 movementInput;

//    void Awake()
//    {
//        rb = GetComponent<Rigidbody2D>();
//       inputActions = new PlayerInputActions();

//        // Subscribe to the movement action
//        inputActions.Player.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
//        inputActions.Player.Move.canceled += ctx => movementInput = Vector2.zero;
//    }

//    void OnEnable()
//    {
//        inputActions.Enable();
//    }

//    void OnDisable()
//    {
//        inputActions.Disable();
//    }

//    void FixedUpdate()
//    {
//        Vector2 movement = movementInput * speed * Time.fixedDeltaTime;
//        rb.velocity = movement;
//    }
//}