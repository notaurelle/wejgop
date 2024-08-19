using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[System.Serializable]
public class QuestGoal: MonoBehaviour
{
    public GoalType goalType; // Type of quest goal (e.g., Kill)
    public int requiredAmount = 1; // Number of kills required
    public int currentAmount; // Current progress
    //public LayerMask enemyLayer; // layer to identify the type of enemy

    //public int ID {  get;  set; }
    public GameObject sign;
    public Quest quest;
    public Teleport teleport;

    //timer
    public float Timer;
    public float MaxTimer = 5;



    public void EnemyKilled()
    {
        // Check if the killed enemy is on the correct layer
        //if (ID == 0)
        //{
            currentAmount++;

        if (IsReached())
        {
            Debug.Log("Goal Reached!");
            // Handle quest completion
            teleport.gameObject.SetActive(true);
            Debug.Log("Teleport is now active!");
            quest.Complete();
        }

        
    }

    private void FixedUpdate()
    {
        if (IsReached())
        {
            sign.gameObject.SetActive(true);
            Timer += Time.deltaTime;
            if (Timer >= MaxTimer)
            {
                sign.gameObject.SetActive(false);
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



