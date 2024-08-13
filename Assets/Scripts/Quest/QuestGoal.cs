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
    public LayerMask enemyLayer; // layer to identify the type of enemy

    // Call this method when an enemy is killed
    public void EnemyKilled(GameObject killedEnemy)
    {
        // Check if the killed enemy is on the correct layer
        if ((enemyLayer & (1 << killedEnemy.layer)) != 0)
        {
            currentAmount++;
            Debug.Log("EnemyKilled called. Killed enemy with layer: " + LayerMask.LayerToName(killedEnemy.layer));
            Debug.Log("Current amount updated: " + currentAmount);
            if (IsReached())
            {
                Debug.Log("Goal Reached!");
                // Handle quest completion
            }
            else
            {
                Debug.LogWarning("EnemyKilled called but enemy layer does not match.");
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



