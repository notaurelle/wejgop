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
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.M)) //IS currently space just for testing
        {
            Attack();
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
        }
    }


    //To see attack.

    void OnDrawGizmosSelected()
    {

        if (attackPoint == null)
            return;


        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        ;
    }

    void Die()
    {
        Debug.Log("Player Healer died!");

        //Disable enemy script as they have 'died'
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

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
        Debug.Log("Healing!");
        //Specific ability related to character
    }
}
