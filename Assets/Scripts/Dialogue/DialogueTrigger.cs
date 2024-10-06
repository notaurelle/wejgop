using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Dialogue[] dialogue;

    public bool startOnTriggerEnter;

    public void TriggerDialogue()
    {
        dialogueManager.StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(startOnTriggerEnter && !dialogueManager.isRunning)
        {
            if (other.CompareTag("Wylla") || other.CompareTag("Ally"))
            {
                dialogueManager.StartDialogue(dialogue);
            }
        }
       
    }
}
