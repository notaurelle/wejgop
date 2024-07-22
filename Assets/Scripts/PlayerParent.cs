using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParent : MonoBehaviour
{
    public bool move;
    public Sprite[] frames;
    [SerializeField] int playerID;

    [SerializeField] GameObject waitingGrp; //GameObject grp to show that its waiting for a player
    [SerializeField] GameObject inputGrp; //GameObject grp to visualise inputs once a player has connected

    [SerializeField] GameObject northButton;
    [SerializeField] GameObject southButton;
    [SerializeField] GameObject westButton;
    [SerializeField] GameObject eastButton;
    [SerializeField] Transform analogStick;

    
    public Vector2 analogInput;

    InputControls playerControls;


    //Movement here.
    private void Start()
    {
        //At the start we will create a callback using the delegate within the InputManager script
        //This will check for the PlayerJoin input to be pressed
        InputManager.instance.onPlayerJoined += AssignInputs;
    }

    private void OnDisable()
    {
        //Cleaning up :)
        InputManager.instance.onPlayerJoined -= AssignInputs;

        // this is for player with controller?
        if (playerControls != null) 
        {
            playerControls.MasterActions.NorthButton.performed -= NorthButton_performed;
            playerControls.MasterActions.NorthButton.canceled -= NorthButton_canceled;
            playerControls.MasterActions.SouthButton.performed -= SouthButton_performed;
            playerControls.MasterActions.SouthButton.canceled -= SouthButton_canceled;
            playerControls.MasterActions.EastButton.performed -= EastButton_performed;
            playerControls.MasterActions.EastButton.canceled -= EastButton_canceled;
            playerControls.MasterActions.WestButton.performed -= WestButton_performed;
            playerControls.MasterActions.WestButton.canceled -= WestButton_canceled;
            playerControls.MasterActions.Movement.performed -= Movement_performed;
            playerControls.MasterActions.Movement.canceled -= Movement_canceled;
        }
    }

    private void Update()
    {
        if (move)
        {
            PerformAbility();
            Animate();
            //change animation.
        }
    }


    public virtual void PerformAbility()
    {
        //Input call this function.
    }

    public void Animate()
    {
        Debug.Log("animate me daddy");
    }

    void AssignInputs(int ID)
    {
        if(playerID == ID)
        {
            //If it matches, we can move the callback since the player has been found
            InputManager.instance.onPlayerJoined -= AssignInputs;

            //Now we can grab the inputs and assign them to this script
            playerControls = InputManager.instance.players[playerID].playerControls;

            playerControls.MasterActions.NorthButton.performed += NorthButton_performed;
            playerControls.MasterActions.NorthButton.canceled += NorthButton_canceled;

            playerControls.MasterActions.SouthButton.performed += SouthButton_performed;
            playerControls.MasterActions.SouthButton.canceled += SouthButton_canceled;

            playerControls.MasterActions.EastButton.performed += EastButton_performed;
            playerControls.MasterActions.EastButton.canceled += EastButton_canceled;

            playerControls.MasterActions.WestButton.performed += WestButton_performed;
            playerControls.MasterActions.WestButton.canceled += WestButton_canceled;

            playerControls.MasterActions.Movement.performed += Movement_performed;
            playerControls.MasterActions.Movement.canceled += Movement_canceled;

            waitingGrp.SetActive(false);
            inputGrp.SetActive(true);
        }

    }

    //Below are just functions for turning gameobjects on/off based on the button thats been pressed
    private void NorthButton_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        northButton.SetActive(true);
    }
    private void NorthButton_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        northButton.SetActive(false);
    }

    private void SouthButton_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        southButton.SetActive(true);
    }
    private void SouthButton_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        southButton.SetActive(false);
    }

    private void EastButton_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        eastButton.SetActive(true);
    }
    private void EastButton_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        eastButton.SetActive(false);
    }

    private void WestButton_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        westButton.SetActive(true);
    }
    private void WestButton_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        westButton.SetActive(false);
    }

    //This is for the analog movement
    private void Movement_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        analogInput = obj.ReadValue<Vector2>();
        UpdateAnalogVisuals();
    }
    private void Movement_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        analogInput = Vector2.zero;
        UpdateAnalogVisuals();
    }

    void UpdateAnalogVisuals()
    {
        analogStick.localPosition = analogInput * 135; //135 is the multipler to make it go all the way to the edge
    }

}
