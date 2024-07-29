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
    public int attackSkill = 100;


    /*
    private void LateUpdate()
    {
        // Lock rotation to ensure the player remains upright
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    */



    void Start()
    {
        currentHealth = maxHealth;
    }

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("DPS has taken DMG");

        if (currentHealth <= 0)
        {
            Die();
        }

    }


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q)) //IS currently space just for testing
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

    void Die()
    {
        Debug.Log("Player DPS died!");

        //Disable enemy script as they have 'died'
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

    }
    //??? dafuq




    public override void PerformAbility()
    {
        base.PerformAbility();

        //if (Input.GetKeyUp(KeyCode.E)) //IS currently space just for testing
        {
            //SkillAttack();
            Debug.Log("DPS used skill!");
        }

        
    }

    /*
    void SkillAttack(int damage)
    {
        
    }
    */
}
