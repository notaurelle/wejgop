using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Dialogue[] dialogue;
    int index;

    public void TriggerDialogue ()
    {
        dialogueManager.StartDialogue(dialogue[index]);
        index++;

    }
}
