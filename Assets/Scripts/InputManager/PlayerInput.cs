using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine; 
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public int playerID;
    public Vector2 Movement;
    InputControls inputControls;
    public float speed = 3;

    public bool attackButton;
    public bool chargedAttackButton;
    public bool northButton;
    public bool westButton;
    public bool southButton; 
    public bool eastButton;

    private Animator anim;
    bool isWalking = false; // bool for walking

    public bool canMove = true;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        if (InputManager.instance.players.Count >= playerID + 1)
        {
            AssignInputs(playerID);
        }
        else
        {
            InputManager.instance.onPlayerJoined += AssignInputs;
        }
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        canMove = true;
    }

    private void Update()
    {
        if (canMove)
        {
            transform.position += (Vector3)Movement * Time.deltaTime * speed;
            if (Movement != Vector2.zero)
            {
                anim.SetBool("IsWalking", true);
                if (Movement.x > 0)
                {
                    spriteRenderer.flipX = false;
                }
                else
                {
                    spriteRenderer.flipX = true;
                }
            }
            else
            {
                anim.SetBool("IsWalking", false);
            }
        }
        
    }

    /* private void OnDisable()
    {
        if (inputControls != null)
        {
            InputManager.instance.onPlayerJoined -= AssignInputs;
            inputControls.MasterActions.Movement.performed -= MovementPerformed;
            inputControls.MasterActions.Movement.canceled -= MovementCanceled;

            
        }
        else
        {
            InputManager.instance.onPlayerJoined -= AssignInputs;
        }
           
    } */
    public void AssignInputs(int ID)
    {
        if(playerID == ID)
        {
            Debug.Log("Assigning inputs " + ID);

            InputManager.instance.onPlayerJoined -= AssignInputs;
            inputControls = InputManager.instance.players[playerID].playerControls;

            inputControls.MasterActions.Movement.performed += MovementPerformed;
            inputControls.MasterActions.Movement.canceled += MovementCanceled;

            inputControls.MasterActions.AttackButton.performed += ctx => attackButton = true;
            inputControls.MasterActions.AttackButton.canceled += ctx => attackButton = false;

            inputControls.MasterActions.ChargeAttackButton.performed += ctx => chargedAttackButton = true;
            inputControls.MasterActions.ChargeAttackButton.canceled += ctx => chargedAttackButton = false;

            inputControls.MasterActions.NorthButton.performed += ctx => northButton = true;
            inputControls.MasterActions.NorthButton.canceled += ctx => northButton = false;

            inputControls.MasterActions.WestButton.performed += ctx => westButton = true;
            inputControls.MasterActions.WestButton.canceled += ctx => westButton = false;

            inputControls.MasterActions.SouthButton.performed += ctx => southButton = true;
            inputControls.MasterActions.SouthButton.canceled += ctx => southButton = false;

            inputControls.MasterActions.EastButton.performed += ctx => eastButton = true;
            inputControls.MasterActions.EastButton.canceled += ctx => eastButton = false;

        }
    } 

    //private void OnDisable()
    //{
    //    if (inputControls != null)
    //    {
    //        // Unsubscribe from the player joined event
    //        InputManager.instance.onPlayerJoined -= AssignInputs;

    //        // Unsubscribe from movement events
    //        inputControls.MasterActions.Movement.performed -= MovementPerformed;
    //        inputControls.MasterActions.Movement.canceled -= MovementCanceled;

    //        // Unsubscribe from attack button events
    //        inputControls.MasterActions.AttackButton.performed -= ctx => attackButton = true;
    //        inputControls.MasterActions.AttackButton.canceled -= ctx => attackButton = false;

    //        // Unsubscribe from charged attack button events
    //        inputControls.MasterActions.ChargeAttackButton.performed -= ctx => chargedAttackButton = true;
    //        inputControls.MasterActions.ChargeAttackButton.canceled -= ctx => chargedAttackButton = false;

    //        // Unsubscribe from additional buttons
    //        inputControls.MasterActions.NorthButton.performed -= ctx => northButton = true;
    //        inputControls.MasterActions.NorthButton.canceled -= ctx => northButton = false;

    //        inputControls.MasterActions.WestButton.performed -= ctx => westButton = true;
    //        inputControls.MasterActions.WestButton.canceled -= ctx => westButton = false;

    //        inputControls.MasterActions.SouthButton.performed -= ctx => southButton = true;
    //        inputControls.MasterActions.SouthButton.canceled -= ctx => southButton = false;

    //        inputControls.MasterActions.EastButton.performed -= ctx => eastButton = true;
    //        inputControls.MasterActions.EastButton.canceled -= ctx => eastButton = false;
    //    }
    //    else
    //    {
    //        InputManager.instance.onPlayerJoined -= AssignInputs;
    //    }
    //}

    public void UpdateAttackBindings()
    {
        if (inputControls != null)
        {
            inputControls.MasterActions.AttackButton.performed += ctx => attackButton = true;
            inputControls.MasterActions.AttackButton.canceled += ctx => attackButton = false;

            inputControls.MasterActions.ChargeAttackButton.performed += ctx => chargedAttackButton = true;
            inputControls.MasterActions.ChargeAttackButton.canceled += ctx => chargedAttackButton = false;
        }
    }


    private void MovementCanceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Movement = Vector2.zero;
    }

    private void MovementPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Movement = obj.ReadValue<Vector2>();
    }
}
