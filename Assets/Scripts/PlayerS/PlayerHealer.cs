using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealer : PlayerParent
{
    //ADDED FROM PlayerDPS Script
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;


    public int maxHealth = 2000;
    private int currentHealth;

    public HealthBar healthBar;

    public int attackDamage = 15;
    public int attackSkill  = 30; //DMG for charged ATK 
 

    private int totalDamageDealt = 0;
    private int damageThreshold = 120;  //Set Value
    private bool canUseChargedAbility = false;
    

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log("Healer has taken DMG");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.KeypadPeriod)) //IS currently space just for testing
        {
            Attack();
        }

        if (canUseChargedAbility && Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            PerformAbility();
        }
    }

    /*
    public void TakeDamage(float damageAmount)
    {
        Health
    }
    */

    void Attack()
    {
        //Play Animation

        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Healer hit" + enemy.name);
            enemy.GetComponent<AIChase>().TakeDamage(attackDamage);
            //value can be set in brackets TD(20) or can add public int

            totalDamageDealt += 15;

            if (totalDamageDealt >= damageThreshold)
            {
                canUseChargedAbility = true;
                Debug.Log("Healer Charged ability is now available!");
            }
        }
    }

    //To see attack.

    void OnDrawGizmosSelected()
    {

        if (attackPoint == null)
            return;


        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void Die()
    {
        Debug.Log("Player Healer died!");

        //Disable enemy script as they have 'died'
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        this.gameObject.SetActive(false);

    }



    /*
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            Heal();
        }
    }

    void Heal()
    {

    }

    */
    public override void PerformAbility()
    {
        base.PerformAbility();
        {
            //Play charged ATK animation

            //Detect enemies in range of Charged attack 
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            //Damage them 
            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("Healer Charged attack hit" + enemy.name);
                enemy.GetComponent<AIChase>().TakeDamage(attackSkill);
                // Reset ability 
                canUseChargedAbility = false;
                totalDamageDealt = 0;

            }
        }
      
        
    }
}
