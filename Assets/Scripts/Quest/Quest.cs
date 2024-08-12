  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //make visual in inspector
public class Quest
{
    public bool isActive;


    public string title;
    public string description;
    public int candyReward;

    public QuestGoal Goal;
    public GameObject sign;

    public void Complete()
    {
        isActive = false;
        Debug.Log(title + " was complete!");
        sign.gameObject.SetActive(true);
    }
}
