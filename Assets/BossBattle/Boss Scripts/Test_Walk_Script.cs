using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Walk_Script : StateMachineBehaviour
{
    public float speed = 3f;
    Transform player;
    Rigidbody rb;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //player = GameObject.FindGameObjectsWithTag("Player").Transform;
        rb = animator.GetComponent<Rigidbody>();    
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Vector2 target = newVector2(player.position.x, player.position.y);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
