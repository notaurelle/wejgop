using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security;
using UnityEngine;

public class PlayerSupport : PlayerParent
{
    PlayerInput playerInput; 

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int maxHealth = 1000;
    private int currentHealth;

    public HealthBar healthBar;

    public GameObject skillImage;

    public int attackDamage = 25;
    public int attackSkill = 75;

    private int totalDamageDealt = 0; // Tracks total damage dealt
    private int damageThreshold = 100;  // Damage needed to activate charged ability
    private bool canUseChargedAbility = false;

    //quest
    public Quest quest;

    //checkpoints - nadine
    private PlayerPos playerPosScript;

    //passive ability to decrease enemy damage within radius
    public float cerwynRadius = 2f; // radius for cerwyn
    [SerializeField] int damageDecrease; // value for amount of damage is being decreased when mobs attack
    public float cooldownDuration = 13f; // how long the cool down is
                                         //  private bool cerwynAbilityOnCooldown = false; // variable to turn cooldown on and off

    public List<AIChase> globs = new List<AIChase>();

    //animation - nadine
    private Animator anim;
    bool isAttacking = false;
    bool isChargedAttacking = false;

    // for audio 
    private AudioClip Cerwyn_BaseATK_SFX;
    private AudioClip Cerwyn_ChargedATK_SFX; 



    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        playerPosScript = GetComponent<PlayerPos>();
        playerInput = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();
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
        if (playerInput.attackButton)
        {
            Attack();
            CerwynBaseSFX();
            playerInput.attackButton = false;
            anim.SetBool("IsAttacking", true);
        }
        else
        {
            anim.SetBool("IsAttacking", false);
        }

        // Check if the Fire3 button is pressed for the charged ability
        if (canUseChargedAbility && playerInput.chargedAttackButton)
        {
            PerformAbility();
            CerwynChargedSFX();
            playerInput.chargedAttackButton = false;
            anim.SetBool("IsChargedAttacking", true);
        }
        else
        {
            anim.SetBool("IsChargedAttacking", false);
        }

        Debuff();
    }

    void Attack()
    {
        AudioSource.PlayClipAtPoint(Cerwyn_BaseATK_SFX, transform.position);
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

    void Debuff()
    {
        foreach(AIChase glob in globs)
        {
            glob.attackDecreased = true;
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

        // disable the script and collider
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        this.gameObject.SetActive(false);

        //updated for checkpoints
        if (playerPosScript != null)
        {
            playerPosScript.RespawnPosition();
        }
        Invoke("Respawn", 1f);
    }
    void Respawn()
    {
        this.gameObject.SetActive(true);
        GetComponent<Collider2D>().enabled = true;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    public override void PerformAbility()
    {
        Debug.Log("Support used charged ability!");
        AudioSource.PlayClipAtPoint(Cerywn_ChargedATK_SFX, transform.position);
        // detect enemies in range of charged attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            AIChase aiChase = enemy.GetComponent<AIChase>();
            if (aiChase != null)
            {
                aiChase.TakeDamage(attackSkill); // deal charged attack damage
                aiChase.ApplyStun();
                skillImage.SetActive(false);
            }
        }

        // reset damage tracking and charged ability flag
        totalDamageDealt = 0;
        canUseChargedAbility = false;
    }

 
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, cerwynRadius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log($"Collider {collision.name}");

        if (collision.gameObject.tag == "Enemy")
        {
            if (!globs.Contains(collision.gameObject.GetComponent<AIChase>()))
            {
                globs.Add(collision.GetComponent<AIChase>());
            }

        }

        //Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, cerwynRadius);

        //foreach (Collider2D enemy in enemies)
        //{
        //    if (enemy.CompareTag("Enemy"))
        //    {
        //        AIChase aIChase = enemy.GetComponent<AIChase>();
        //        if (aIChase != null)
        //        {
        //            //aIChase.attackDamage -= damageDecrease;
        //            aiChase.attackDecreased = true; 
        //            Debug.Log("cerwyn decreases enemy attack");
        //        }

        //    }
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (globs.Contains(collision.gameObject.GetComponent<AIChase>()))
            {
                globs.Remove(collision.GetComponent<AIChase>());
                Debug.Log("Decrease stop");
                collision.GetComponent<AIChase>().attackDecreased = false;
            }
        }

        //Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, cerwynRadius);

        //foreach (Collider2D enemy in enemies)
        //{
        //    if (enemy.CompareTag("Enemy"))
        //    {
        //        AIChase aIChase = enemy.GetComponent<AIChase>();
        //        if (aIChase != null)
        //        {
        //            //aiChase.attackDamage += damageDecrease;
        //            aiChase.attackDecreased = false;
        //            Debug.Log("cerwyn reset");
        //        }

        //    }
        //}
    }

    public void CerwynBaseSFX()
    {
        AudioManager.instance.PlaySFX(Cerwyn_BaseATK_SFX, 1.0f);
    }

    public void CerwynChargedSFX()
    {
        AudioManager.instance.PlaySFX(Cerwyn_ChargedATK_SFX, 1.0f);
    }
}


