using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Dialogue[] dialogue;

    public BoxCollider2D boxCollider;
    //public GameObject pause;
    public GameObject next;

    public bool startOnTriggerEnter;

    public void TriggerDialogue()
    {
        dialogueManager.StartDialogue(dialogue);
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (startOnTriggerEnter && !dialogueManager.isRunning)
        {
            if (other.CompareTag("Wylla") || other.CompareTag("Ally"))
            {
                dialogueManager.StartDialogue(dialogue);

                boxCollider = this.GetComponent<BoxCollider2D>();
                if (boxCollider != null)
                {
                    boxCollider.enabled = false;

                    next.SetActive(true);

                    //if (!dialogueManager.isRunning)
                    //{
                    //    next.SetActive(false);
                    //}
                    ////pause.SetActive(false);
                }
            }
        }
    }

}
