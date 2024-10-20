using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Image dialogueImage;

    public Animator animator;

    Dialogue[] currentDialogue;
    int currentDialogueIndex;

    public bool isRunning;
    public PlayerInput[] players;

   public void StartDialogue (Dialogue[] dialogue)
    {
        currentDialogueIndex = 0;
        currentDialogue = dialogue;
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue[0].characterName;
        dialogueImage.sprite = dialogue[0].characterSprite;
        StartCoroutine(TypeSentence(dialogue[0].dialogue));

        isRunning = true;

        foreach (PlayerInput p in players)
        {
            p.canMove = false;
        }
    }

    public void DisplayNextSentence()
    {
        currentDialogueIndex++;
        if (currentDialogueIndex >= currentDialogue.Length)
        {
            EndDialogue();
            return;
        }

        StopAllCoroutines();
        nameText.text = currentDialogue[currentDialogueIndex].characterName;
        dialogueImage.sprite = currentDialogue[currentDialogueIndex].characterSprite;
        StartCoroutine(TypeSentence(currentDialogue[currentDialogueIndex].dialogue));
    }

    public float typingSpeed = 0.02f; //can adjust speed
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        isRunning = false;


        foreach (PlayerInput p in players)
        {
            p.canMove = true;
        }
    }
}
