using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    private GameManager gameManager;
    public PlayerInput[] players; 

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    
        //transform.position = gameManager.lastCheckPointPos;
    }
    public void RespawnPosition()
    {
        if (gameManager != null)
        {
            transform.position = gameManager.lastCheckPointPos;
            
           
            

            //PlayerInput playerInput = GetComponent<PlayerInput>();
            //if (playerInput != null)
            //{
            //    playerInput.AssignInputs(playerInput.playerID);
            //    playerInput.UpdateAttackBindings(); // reassign attacks 
                
            //}
        }
    }
}

    

