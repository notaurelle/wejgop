  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //make visual in inspector
public class Quest
{
    public bool isActive;


    public string title;
    public string description;
    public string requiredAmount;
    public string currentAmount;
    public string candyAmount;
    public int candyReward;

    public GameObject progressTracker;

    public QuestGoal Goal;



    public void Complete()
    {
        isActive = false;
        Debug.Log(title + "This quest was completed");
        candyReward++;


    }
}
