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

    public GameObject skillImage;

    public int attackDamage = 40;
    public int attackSkill = 100;

    private int totalDamageDealt = 0; // Tracks total damage dealt
    private int damageThreshold = 120;  // Damage needed to activate charged ability
    private bool canUseChargedAbility = false;

    //quest
    public Quest quest;

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
        // Check if the Fire1 button is pressed for attack
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

        // Check if the Fire3 button is pressed for the charged ability
        if (canUseChargedAbility && Input.GetButtonDown("Fire3"))
        {
            PerformAbility();
        }
    }

    void Attack()
    {
        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage enemies and track total damage dealt
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Support hit " + enemy.name);
            AIChase aiChase = enemy.GetComponent<AIChase>();
            if (aiChase != null)
            {
                aiChase.TakeDamage(attackDamage);
                aiChase.ApplyStun();
                totalDamageDealt += attackDamage; // Track the total damage dealt

                // Check if the threshold is reached
                if (totalDamageDealt >= damageThreshold)
                {
                    canUseChargedAbility = true;
                    skillImage.SetActive(true);
                    Debug.Log("Charged ability is now available!");
                }
            }
        }

        if (totalDamageDealt >= damageThreshold)
        {
            foreach (Collider2D enemy in hitEnemies)
            {
                AIChase aiChase = enemy.GetComponent<AIChase>();
                if (aiChase != null)
                {
                    aiChase.ApplyStun();
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void Die()
    {
        Debug.Log("Player Support died!");

        // Disable the script and collider
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        this.gameObject.SetActive(false);
    }

    public override void PerformAbility()
    {
        Debug.Log("Support used charged ability!");

        // Detect enemies in range of charged attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            AIChase aiChase = enemy.GetComponent<AIChase>();
            if (aiChase != null)
            {
                aiChase.TakeDamage(attackSkill); // Deal charged attack damage
                aiChase.ApplyStun();
                skillImage.SetActive(false);
            }
        }

        // Reset damage tracking and charged ability flag
        totalDamageDealt = 0;
        canUseChargedAbility = false;
    }

    void PassiveAbility()
    {
        // Implement passive ability logic here if needed
    }
}