using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        transform.position = gameManager.lastCheckPointPos;
    }
    public void RespawnPosition()
    {
        if (gameManager != null)
        {
            transform.position = gameManager.lastCheckPointPos;
        }
    }
}

    

