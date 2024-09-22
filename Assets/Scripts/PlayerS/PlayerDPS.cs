using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDPS : PlayerParent
{
    // NOTE FOR ANYONE WHO SEES THIS YOU BASICALLY CANT SEE ATTACK REGISTER WITHOUT AN ANIMATION SPRITE :0

    PlayerInput playerInput;  // so we can use player input.cs here - nadine
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;


    public int maxHealth = 1000;
    public int currentHealth;

    public GameObject skillImage;
    public Color newColor = Color.red;

    public HealthBar healthBar;

    public int attackDamage = 40;
    public int attackSkill = 100; // DMG for charged ATK
    //public int chargedAttackDamage = 100;


    private int totalDamageDealt = 0; //Changing Value
    private int damageThreshold = 120;  //Set Value
    private bool canUseChargedAbility = false;


    //Quests
    public Quest quest;



    //public int candy;
    public AIChase mob;

    //respawn method reference
    private PlayerPos playerPosScript; 
    // nadine needs this reference to make checkpoint function

    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        playerPosScript = GetComponent<PlayerPos>();
        playerInput = GetComponent<PlayerInput>();  
        // references player pos script - nadine

    }

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log("DPS has taken DMG");
        //spriteRenderer = GetComponent<SpriteRenderer>();

        if (currentHealth <= 0)
        {
            Die();
        }

    }


    private void Update()
    {
        if (playerInput.attackButton) //changed for all three players are now referencing playerinput.cs
        {
            Attack();
            playerInput.attackButton = false;
        }
        
        if (canUseChargedAbility && playerInput.chargedAttackButton)
        {
            PerformAbility();
            playerInput.chargedAttackButton = false;
        }

        //Call function
     
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
                skillImage.SetActive(true);
                Debug.Log("DPS Charged ability is now available!");
            }
            // notifies quest system
            //GoBattle();
        }
    }

    // Add the below function to AIChase script?
    public void GoBattle()
    {
        if (quest.isActive)
        {
            quest.Goal.EnemyKilled();
            if (quest.Goal.IsReached())
            {
                candy += quest.candyReward;

                quest.Complete();
            }
        }
    }

    /*
    public void GoBattle()
    {
        if (quest != null && quest.isActive)
        {
            // Pass the tag of the enemy to the QuestGoal
            if (quest.Goal != null)
            {
                quest.Goal.EnemyKilled(gameObject); // Pass the tag instead of the gameObject

                if (quest.Goal.IsReached())
                {
                    // Reward the player
                    candy += quest.candyReward; // Ensure 'candy' is defined in the context

                    // Complete the quest
                    quest.Complete();
                }
            }
        }
    }
    */
    

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

        // nadine - made changes here
        if (playerPosScript != null)
        {
            playerPosScript.RespawnPosition();
        }

        Invoke("Respawn", 1f);
    }
    
    void Respawn() // nadine added this
    {
        this.gameObject.SetActive(true);
        GetComponent<Collider2D>().enabled=true;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }




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
                skillImage.SetActive(false);
                totalDamageDealt = 0;

            }

        }

    }

}
