using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[System.Serializable]
public class QuestGoal: MonoBehaviour
{
    public GoalType goalType; // Type of quest goal (e.g., Kill)
    public int requiredAmount = 1; // Number of kills required
    public int currentAmount; // Current progress
    //public LayerMask enemyLayer; // layer to identify the type of enemy

    public int ID {  get;  set; }
    public AIChase mob;

    public int enemyLayer;  // The specific layer number you want to check
    

    public void EnemyKilled()
    {
        // Check if the killed enemy is on the correct layer
        if (ID == 0)
        {
            currentAmount++;


            if (IsReached())
            {
                Debug.Log("Goal Reached!");
                // Handle quest completion
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



