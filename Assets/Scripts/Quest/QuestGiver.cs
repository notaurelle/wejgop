using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public QuestGoal goal;
    public AIChase Mob;
    public BattleSystem battleSystem;

    public GameObject questWindow;
    public Text titleText;
    public Text descriptionText;
    public Text candyText;
    public Text requiredAmountText;
    public GameObject questButton;

    private bool isPlayerInRange = false;

    //public List<AIChase> Enemy = new List<AIChase>();


    //trying something out - aurelia
    public GameObject progressTracker;

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (questWindow.activeSelf)
            {
                CloseQuestWindow();
            }
            else
            {
                OpenQuestWindow();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ally") || other.CompareTag("Wylla"))
        {
            questButton.SetActive(true);
            isPlayerInRange = true;

        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ally") || other.CompareTag("Wylla"))
        {
            questButton.SetActive(false);
            isPlayerInRange = false;
        }
    }


    public void OpenQuestWindow()

    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        candyText.text = quest.candyAmount;
        requiredAmountText.text = quest.requiredAmount;

        //Mob.gameObject.SetActive(false);
        //Mob.enabled = false;
    }


    public void CloseQuestWindow()
    {
        questWindow.SetActive(false);
        //Mob.gameObject.SetActive(true);
    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;
        progressTracker.gameObject.SetActive(true); //- trying something out - aurelia
        //Mob.gameObject.SetActive(true);



        //30/09 StartBattle script
        //battleSystem.StartBattle();
        /*
        if (Mob != null)
        {


            Mob.gameObject.SetActive(true); //Ensure mob is active
            
        }
        */
    }

    /*
    //Method to handle enemy kill from mob
    public void HandleEnemyKill(GameObject killedEnemy)
    {
        if(quest != null && quest.Goal != null)
        {
            quest.Goal.EnemyKilled(killedEnemy);
        }
    }
    */
}


