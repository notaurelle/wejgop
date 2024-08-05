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

    private int totalDamageDealt = 0; //Changing Value
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
        Debug.Log("Support has taken DMG");

        if (currentHealth <= 0)
        {
            Die();
        }

    }


    private void Update()
    {
        // Check if the Cross button (✕) is pressed for attack
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

        // Check if the Triangle button (△) is pressed for the charged ability
        if (canUseChargedAbility && Input.GetButtonDown("Fire3"))
        {
            PerformAbility();
        }
    }

    void Attack()
    {
        //animation
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Support hit " + enemy.name);
            AIChase aiChase = enemy.GetComponent<AIChase>();
            if (aiChase != null)
            {
                aiChase.TakeDamage(attackDamage);
                aiChase.ApplyStun();
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
        Debug.Log("Player Support died!");

        //Disable enemy script as they have 'died'
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

    }

    void PassiveAbility()
    {

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
