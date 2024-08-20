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
    public GameObject questWindow;
    public Text titleText;
    public Text descriptionText;
    public GameObject questButton;


    //trying something out - aurelia
    public GameObject progressTracker;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ally") || other.CompareTag("Wylla"))
        {
            questButton.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ally") || other.CompareTag("Wylla"))
        {
            questButton.SetActive(false);
        }
    }


    public void OpenQuestWindow()
    { 
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        Mob.gameObject.SetActive(false);
        //Mob.enabled = false;
    }


    public void CloseQuestWindow()
    {
        questWindow.SetActive(false);
        Mob.gameObject.SetActive(true);
    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;
        //progressTracker.gameObject.SetActive(true); - trying something out - aurelia
        if (Mob != null)
        {
            Mob.gameObject.SetActive(true); //Ensure mob is active
            
        }
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


