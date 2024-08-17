using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public AIChase Mob;
    public GameObject questWindow;
    public Text titleText;
    public Text descriptionText;


    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        //Mob.gameObject.SetActive(false);
        Mob.enabled = false;
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


