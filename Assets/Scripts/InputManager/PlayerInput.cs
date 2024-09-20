using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine; 
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public int playerID;
    public InputManager inputManager;
    public Vector2 Movement;
    InputControls inputControls;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        inputManager.onPlayerJoined += AssignInputs;
    }

    private void Update()
    {
        transform.position += (Vector3)Movement * Time.deltaTime * speed;
    }

    private void OnDisable()
    {
        if (inputControls != null)
        { 
           inputManager.onPlayerJoined -= AssignInputs;
            inputControls.MasterActions.Movement.performed -= MovementPerformed;
            inputControls.MasterActions.Movement.canceled -= MovementCanceled;
        }
        else
        {
            inputManager.onPlayerJoined -= AssignInputs;
        }
           
    }
    void AssignInputs(int ID)
    {
        if(playerID == ID)
        {
            inputManager.onPlayerJoined = AssignInputs;
            inputControls = inputManager.players[playerID].playerControls;
            inputControls.MasterActions.Movement.performed += MovementPerformed;
            inputControls.MasterActions.Movement.canceled += MovementCanceled;
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
