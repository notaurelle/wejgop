using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerDPS : PlayerParent
{
    // NOTE FOR ANYONE WHO SEES THIS YOU BASICALLY CANT SEE ATTACK REGISTER WITHOUT AN ANIMATION SPRITE :0

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;


    public int maxHealth = 1000;
    private int currentHealth;

    public int attackDamage = 40;
    void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("DPS has taken DMG"); 
    } 
 
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) //IS currently space just for testing
        {
            Attack();
        }
    }

    void Attack()
    {
        //Play Animation

        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("DPS hit" + enemy.name);
            enemy.GetComponent<AIChase>().TakeDamage(attackDamage);
            //value can be set in brackets TD(20) or can add public int
        }
    }

    //To see attack.

    void OnDrawGizmosSelected()
    {
        
        if(attackPoint == null)            
                return;
        

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
;   }

    public override void PerformAbility()
    {
        base.PerformAbility();

        Debug.Log("DPS!");
    }


}
