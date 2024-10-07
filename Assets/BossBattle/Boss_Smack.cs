using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss_Smack : MonoBehaviour
{
    // will cover player detection and attacks for all three phases) 
    public float speed;
    public float attackRange = 2f;

    Transform player;
    Rigidbody rb;
    // Boss boss; - brianna this needs to b fixed << was noted because it gave game errors

    //Attack for phases
    public int smackDamage = 30;
    public int phaseTwoAttackDamage = 100;
    public Vector2 attackOffset;

    /*override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Ally") || GameObject.FindGameObjectsWithTag("Wylla").transform;
        rb = animator.GetComponent<Rigidbody>();
        boss = animator.GetComponent<Boss>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, InspectorToggleLeftAttribute layerIndex)
    {
        boss.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }


    override public void OnStateExit(Animator animator,  AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack"); 
    }
    */

    public void PhaseOne() // smack
    {

    }

    public void PhaseTwo() // Summon mobs 
    {

    }

    public void PhaseThree()
    {

    }// holy water does damage 
}
