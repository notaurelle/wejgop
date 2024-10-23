using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Image dialogueImage;

    public Animator animator;

    //public GameObject startButton;
    //public GameObject battleButton;
   // public GameObject startConvo;

    Dialogue[] currentDialogue;
    int currentDialogueIndex;

    public bool isRunning;
    public PlayerInput[] players;

    public Dialogue[] sceneDialogue;
    public Dialogue[] anotherSceneDialogue;

    public string sceneNameToTriggerDialogue1 = "FinalScene"; //make sure to set in the inspector as well
    public string sceneNameToTriggerDialogue2 = "Cutscene";

    void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == sceneNameToTriggerDialogue1 && sceneDialogue.Length > 0)
        {
            StartDialogue(sceneDialogue);
        }
        else if (currentSceneName == sceneNameToTriggerDialogue2 && anotherSceneDialogue.Length > 0)
        {
            StartDialogue(anotherSceneDialogue);
        }
    }

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
        
        //startButton.SetActive(true);
        
        //battleButton.SetActive(true);
        //startConvo.SetActive(false);


        foreach (PlayerInput p in players)
        {
            p.canMove = true;
        }
    }
}
