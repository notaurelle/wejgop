using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    //Player Reference
    public PlayerDPS Harry; //this script is using Harry.
    public PlayerHealer Wylla;
    public PlayerSupport Cerwyn;
    public PlayerParent Player; 
    

    public AIChase Mob;

    


    public GameObject questWindow;
    public Text titleText;
    public Text descriptionText;


    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;   
        Mob.gameObject.SetActive(false);
    }

    public void CloseQuestWindow()
    {
        questWindow.SetActive (false);
        Mob.gameObject.SetActive(true);
    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;
        Mob.gameObject.SetActive(true);

        // Assign the quest to each referenced player
        if (Harry != null)
        {
            Harry.quest = quest;
        }

        if (Wylla != null)
        {
            Wylla.quest = quest;
        }

        if (Cerwyn != null)
        {
            Cerwyn.quest = quest;
        }
    }
}

