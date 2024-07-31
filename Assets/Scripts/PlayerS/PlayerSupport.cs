using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSupport : PlayerParent
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;


    public int maxHealth = 1000;
    private int currentHealth;

    public HealthBar healthBar;

    public int attackDamage = 40;
    public int attackSkill = 100;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log("Support has taken DMG");

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
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Support hit" + enemy.name);
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
        Debug.Log("Player Support died!");

        //Disable enemy script as they have 'died'
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

    }



    /*
    public override void PerformAbility()
    {
        base.PerformAbility();

        //if (Input.GetKeyUp(KeyCode.E)) //IS currently space just for testing
        {
            //SkillAttack();
            Debug.Log("Support used skill!");
        }


    }
    */
}
