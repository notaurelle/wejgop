using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType; // Type of quest goal (e.g., Kill)
    public int requiredAmount = 1; // Number of kills required
    public int currentAmount; // Current progress
    public string enemyTag; // Tag to identify the type of enemy

    // Call this method when an enemy is killed
    public void EnemyKilled(string killedEnemyTag)
    {
        if (goalType == GoalType.Kill)
        {
            if(killedEnemyTag == enemyTag)
            {
                currentAmount += 1;
                Debug.Log("EnemyKilled called. Killed enemy with tag: " + killedEnemyTag);
                Debug.Log("Current amount updated: " + currentAmount);
            }
            else
            {
                Debug.LogWarning("EnemyKilled called but enemy tag does not match.");
            }
        }
    }

    // Method to check if the goal is reached
    public bool IsReached()
    {
        return currentAmount >= requiredAmount;
    }
}

public enum GoalType
{
    Kill, // Goal type for killing enemies
    Gathering // Goal type for collecting items


    //Pick up item quests
    /*
    public void ItemCollected()
    {
        if (goalType == GoalType.Gathering)
            currentAmount++;
    }
    */
}



