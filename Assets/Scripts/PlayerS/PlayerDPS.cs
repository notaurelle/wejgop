using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDPS : PlayerParent
{
    // NOTE FOR ANYONE WHO SEES THIS YOU BASICALLY CANT SEE ATTACK REGISTER WITHOUT AN ANIMATION SPRITE :0

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;


    public int maxHealth = 1000;
    private int currentHealth;

    public HealthBar healthBar;

    public int attackDamage = 40;
    public int attackSkill = 100; // DMG for charged ATK
    //public int chargedAttackDamage = 100;


    private int totalDamageDealt = 0; //Changing Value
    private int damageThreshold = 120;  //Set Value
    private bool canUseChargedAbility = false;


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
        healthBar.SetMaxHealth(maxHealth);
    }

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
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
        
        if (canUseChargedAbility && Input.GetKeyUp(KeyCode.E))
        {
            PerformAbility();
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

            totalDamageDealt += 40;

            if (totalDamageDealt >= damageThreshold)
            {
                canUseChargedAbility = true;
                Debug.Log("DPS Charged ability is now available!");
            }
        }
    }

    /*
    void ChargedAttack()
    {
        // Play Charged Attack Animation 

        //Detect enemies in range of Charged attack 
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage them 
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("DPS Charged attack hit" + enemy.name);
            enemy.GetComponent<AIChase>().TakeDamage(attackSkill);
        }

        // Reset ability 
        canUseChargedAbility = false;
        totalDamageDealt = 0;
    }
    */

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
        this.gameObject.SetActive(false);

    }
    //??? dafuq




    public override void PerformAbility()
    {
        base.PerformAbility();

        {
            // Play Charged Attack Animation 

            //Detect enemies in range of Charged attack 
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            //Damage them 
            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("DPS Charged attack hit" + enemy.name);
                enemy.GetComponent<AIChase>().TakeDamage(attackSkill);
                // Reset ability 
                canUseChargedAbility = false;
                totalDamageDealt = 0;

            }

            /*
            // Reset ability 
            canUseChargedAbility = false;
            totalDamageDealt = 0;
            */
        }


        /*
        //if (Input.GetKeyUp(KeyCode.E)) //IS currently space just for testing
        {
            //SkillAttack();
            Debug.Log("DPS used skill!");
            Debug.Log("Charged ATK has been used!");
        }
        */

    }

    /*
    void SkillAttack(int damage)
    {
        
    }
    */
}
