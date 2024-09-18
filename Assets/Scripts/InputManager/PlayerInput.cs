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

    // Start is called before the first frame update
    void Start()
    {
        inputManager.onPlayerJoined += AssignInputs;
    }

    private void OnDisable()
    {
        if (inputControls != null)
        {
           inputManager.onPlayerJoined -= AssignInputs;
           //inputControls.MasterControls.Movement.performed -= MovementPerformed;
           //inputControls.MasterControls.Movement.canceled -= MovementCanceled;
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
            //inputControls.MasterControls.Movement.performed += MovementPerformed;
            //inputControls.MasterControls.Movement.canceled += MovementCanceled;
        }
    }

    private void MovementCanceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Movement = Vector2.zero;
    }

    private void MovementPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }
}
