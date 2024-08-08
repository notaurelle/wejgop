using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZone : MonoBehaviour

{
    //Players
    public PlayerDPS Harry;
    public PlayerHealer Wylla;
    public PlayerSupport Cerwyn;
    
    
    // Public variable to assign the camera in the Inspector
    public Transform cameraTransform;

    // The new position for the camera when the player enters the trigger zone
    public Vector3 newCameraPosition;

    public Vector3 newPlayerPosition;

    // List to keep track of players within the trigger zone
    private HashSet<Collider2D> playersInZone = new HashSet<Collider2D>();

    // The total number of players that need to be in the zone to trigger the camera change
    public int requiredPlayerCount = 3;

    // Boolean flag to track whether the camera has been switched
    private bool isCameraSwitched = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Object entered trigger: " + other.name);

        // Check if the collider belongs to a player
        if (other.CompareTag("Ally"))
        {
            playersInZone.Add(other);

            // Check if the required number of players are in the zone
            if (playersInZone.Count >= requiredPlayerCount)
            {
                if (!isCameraSwitched)
                {
                    // Switch the camera's position
                    if (cameraTransform != null)
                    {
                        cameraTransform.position = newCameraPosition;
                        Debug.Log("Camera position updated to: " + newCameraPosition);
                        isCameraSwitched = true;
                    }
                    else
                    {
                        Debug.LogWarning("CameraTransform is not assigned.");
                    }

                    // Optionally relocate players
                    RelocatePlayers();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ally"))
        {
            playersInZone.Remove(other);

            // Check if we need to reset the camera if players leave the zone
            if (playersInZone.Count < requiredPlayerCount)
            {
                if (isCameraSwitched)
                {
                    // Reset the camera to its original position
                    ResetCameraPosition();
                }
            }
        }
    }

    private void RelocatePlayers()
    {
        // Implement player relocation logic here if needed
        // For example:
        Debug.Log("Relocating players to the next area...");
        Harry.transform.position = newPlayerPosition;
        Wylla.transform.position = newPlayerPosition;  
        Cerwyn.transform.position = newPlayerPosition;


    }

    private void ResetCameraPosition()
    {
        // Implement logic to reset the camera to its original position
        // You might need to store the original position somewhere
        Debug.Log("Resetting camera position to the original settings...");
    }
}


/*
{
    // Public variable to assign the camera in the Inspector
    public Transform cameraTransform;

    // The new position for the camera when the player enters the trigger zone
    public Vector3 newCameraPosition;

    private bool isCameraSwitched = false;

    // This method is called when another collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Object entered trigger: " + other.name);

        // Check if the collider belongs to the player
        if (other.CompareTag("Ally"))
            //needs to count all three players are in box collider
            //relocate player to next area

        {
            isCameraSwitched = !isCameraSwitched;
            // Transform the camera's position
            if (cameraTransform != null)
            {
                cameraTransform.position = newCameraPosition;
                Debug.Log("Camera position updated to: " + newCameraPosition);
            }
            else
            {
                Debug.LogWarning("CameraTransform is not assigned.");
            }
        }
    }
}
*/