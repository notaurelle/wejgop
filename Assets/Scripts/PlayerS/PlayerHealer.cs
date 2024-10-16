using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealer : PlayerParent
{
    PlayerInput playerInput;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers; // LayerMask for enemies (not used in healing)
    public LayerMask playerLayers; // LayerMask for enemies (not used in healing)

    public HealthBar healthBar; // Reference to the HealthBar script

    public GameObject skillImage;
    public GameObject healImage;

    public int maxHealth = 2000;
    public int currentHealth;

    public int attackDamage = 15;
    public int attackSkill = 30; // DMG for charged ATK 

    private int totalDamageDealt = 0;
    private int damageThreshold = 85; // Set Value
    private bool canUseChargedAbility = false;

    public float healingRadius = 2f; // Radius for healing
    public int healingAmount = 20; // Amount of health to heal per interval
    public float healingInterval = 1f; // How often to heal (in seconds) 

    //quest
    public Quest quest;

    //Checkpoin pos reference to script same as PlayerDPS- nadine
    private PlayerPos playerPosScript;

    //attack animations
    private Animator anim;
    bool isAttacking = false;
    bool isChargedAttacking = false;
    bool isHealing = false;

    //audio
    [SerializeField]
    private AudioClip Wylla_BaseATK_SFX;
    [SerializeField]
    private AudioClip Wylla_ChargedATK_SFX;
   




    void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        playerPosScript = GetComponent<PlayerPos>();
        playerInput = GetComponent<PlayerInput>();
        anim = GetComponent<Animator>();

        // Start healing coroutine
        StartCoroutine(PassiveHealing());
        
    }

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        //Debug.Log("Healer has taken DMG");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Update()
    {
        if (playerInput.attackButton) // Change KeyCode as needed
        {
            Attack();
            playerInput.attackButton = false;
            anim.SetBool("IsAttacking", true);

        }
        else
        {
            anim.SetBool("IsAttacking", false); 
        }

        if (canUseChargedAbility && playerInput.chargedAttackButton)
        {

            PerformAbility();
            playerInput.chargedAttackButton = false;
            anim.SetBool("IsChargedAttacking", true);

        }
        else
        {
            anim.SetBool("IsChargedAttacking", false); 
        }

        void Attack()
        {
            //plays audio
            AudioSource.PlayClipAtPoint(Wylla_BaseATK_SFX, transform.position);

            // Detect enemies in range of attack
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            // Damage them
            foreach (Collider2D enemy in hitEnemies)
            {
                //Debug.Log("Healer hit " + enemy.name);
                enemy.GetComponent<AIChase>().TakeDamage(attackDamage);

                totalDamageDealt += attackDamage;

                if (totalDamageDealt >= damageThreshold)
                {
                    canUseChargedAbility = true;
                    skillImage.SetActive(true);
                    // Debug.Log("Healer Charged ability is now available!");
                }
            }
        }

       
    }

    public override void PerformAbility()
    {
        base.PerformAbility();
            // Play charged ATK animation

            // Detect enemies in range of Charged attack
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            // Damage them
            foreach (Collider2D enemy in hitEnemies)
            {
                //Debug.Log("Healer Charged attack hit " + enemy.name);
                enemy.GetComponent<AIChase>().TakeDamage(attackSkill);

                // Reset ability
                canUseChargedAbility = false;
                skillImage.SetActive(false);
                totalDamageDealt = 0;

            }
                
    }

    private void HealAlliesInRange()
    {
        // finds all GameObjects within the healing radius
        Collider2D[] allies = Physics2D.OverlapCircleAll(transform.position, healingRadius, playerLayers);


        foreach (Collider2D ally in allies)
        {
            if (ally.CompareTag("Ally")) // checks for tag
            {
                HealthBar allyHealthBar = ally.GetComponent<HealthBar>();
                if (allyHealthBar != null)
                {
                    // increases ally's health but won't exceed the max
                    int newHealth = Mathf.Min((int)allyHealthBar.slider.maxValue, (int)allyHealthBar.slider.value + healingAmount);
                    allyHealthBar.SetHealth(newHealth);
                    //Debug.Log("Healed " + ally.name);
                    healImage.SetActive(true);


                }
            }
            else
            {
                healImage.SetActive(false);
            }
        }

    }    

    private IEnumerator PassiveHealing()
    {
        while (true)
        {
            HealAlliesInRange();
            yield return new WaitForSeconds(healingInterval);
            
            
        }
        
    }

    private void Die()
    {
        Debug.Log("Player Healer died!");

        // Disable the script and collider
        GetComponent<Collider2D>().enabled = false;
        this.gameObject.SetActive(false);

        //checkpoints 
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, healingRadius);
    }

    public void WyllaAttackSFX()
    {
        //plays audio
        AudioSource.PlayClipAtPoint(Wylla_BaseATK_SFX, transform.position);
    }

    public void WyllaChargedAttackSFX()
    {
        //plays audio
        AudioSource.PlayClipAtPoint(Wylla_ChargedATK_SFX, transform.position);
    }
}
