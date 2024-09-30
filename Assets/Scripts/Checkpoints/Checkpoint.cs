using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Checkpoint : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();  
        if (other.CompareTag("Ally") || other.CompareTag("Wylla"))
        {
            gameManager.lastCheckPointPos = transform.position;
            Debug.Log("Checkpoint reached:" + gameManager.lastCheckPointPos);
        }
    }
}
