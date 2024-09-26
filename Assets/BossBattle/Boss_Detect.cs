using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Detect : StateMachineBehaviour
{

    Transform player;
    Transform wylla;
    Rigidbody rb;
    public float speed = 2.5f;
    public float attackRange = 3f;
    Boss boss;
   // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Ally").transform;
        wylla = GameObject.FindGameObjectWithTag("Wylla").transform;
        animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
    }

   // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        Vector2 target = new Vector2(player.position.y, rb.position.x);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
        // this logic should allow the boss to follow the player's position if it no work swap x and y 

        if(Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("PhaseOne");
        }
    }


   // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("PhaseOne");
    }

}
