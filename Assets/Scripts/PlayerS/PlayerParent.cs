using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerParent : MonoBehaviour
{
    public bool move; // this doesnt make layer move it only sets this active
    public Sprite[] frames;
    private Vector2 moveInputValue;
    public int candy;

    //Quests
    //public Quest quest;

    //Movement here.


    public virtual void TakeDamage(int Damage)
    {

    }

    public virtual void HealPlayer(int Heal)
    {

    }

    /*
    public void GoBattle()
    {
        if (quest.isActive)
        {
            quest.Goal.EnemyKilled();
            if (quest.Goal.IsReached())
            {
                candy += quest.candyReward;
            }
        }
        
    }
    */

    private void Update()
    {

        if (move)
        {
            PerformAbility();
            //Animate();
            //change animation.
        }

        MoveLogic();
    }

    private void OnMove(InputValue value)
    {
        Debug.Log("plz work");
        moveInputValue = value.Get<Vector2>();
    }

    private void MoveLogic()
    {
        transform.Translate(moveInputValue * Time.deltaTime * 5);
    }


    public virtual void PerformAbility()
    {
        //Input call this function. for abilities 
    }

    public void Animate()
    {
        Debug.Log("animate me daddy");
    }

    
}
