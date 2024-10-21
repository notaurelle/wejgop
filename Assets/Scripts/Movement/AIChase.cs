using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIChase : MonoBehaviour, IEnemyDamage
{
    public List<GameObject> players;
    public float speed;
    public float distanceBetween;

    private GameObject closestPlayer;


    [SerializeField] private Slider slider;
    public Gradient gradient;
    public Image fill;


    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;

    public GameObject mobHP;

    public int maxHealth = 100;
    private int currentHealth;
    private bool hasDied = false; // this is new 


    public int attackDamage = 5;
    public int decreaseDamage = 4;
    public bool attackDecreased = false; 

    //timer
    public float Timer;
    public float attackTimer = 3;

    //stun properties 
    public bool stunned = false;
    public float stunDuration = 2f;

    public HealthBar healthBar;

    // quest tingz
    public QuestGoal questGoal;
    public QuestGiver questGiver;
    public int ID { get; set; }
    // public Quest quest; //reference to quest 

    // animation 
    public Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        ID = 0;
        animator = GetComponent<Animator>();
    }

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue; //checking
        slider.maxValue = maxHealth;
        slider.value = currentHealth;

        fill.color = gradient.Evaluate(1f);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Debug.Log("MOB DMG Player");

        if (currentHealth <= 0)
        {
            Die();
            //questGiver.Enemy.Remove(GetComponent<AIChase>());
            //questGoal.currentAmount += 1;
        }

    }

    private void FixedUpdate()
    {
        if (!stunned)
        {
            Timer += Time.deltaTime;
            if (Timer >= attackTimer)
            {
                attackPlayer();
                Timer = 0;
            }
            MoveTowardsPlayer();
        }
    }

    void attackPlayer()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        //Damage them
        foreach (Collider2D player in hitPlayers)
        {
            Debug.Log("Mob hit " + player.name);
            //Short hand for if statement
            player.GetComponent<PlayerParent>().TakeDamage(attackDecreased == true ? attackDamage - decreaseDamage : attackDamage);


            //value can be set in brackets TD(20) or can add public int
        }
    }

    public void ApplyStun()
    {
        if (!stunned)
        {
            stunned = true;
            if (animator != null)
            {
                animator.SetBool("IsStunned", true); // sets the animation parameter 
            }

            StartCoroutine(StunCoroutine());
        }
    }

    private IEnumerator StunCoroutine()
    {
        //Add visual and audio
        Debug.Log("Stun started");
        yield return new WaitForSeconds(stunDuration);
        Debug.Log("Stun ended.");
        stunned = false;

        if (animator != null)
        {
            animator.SetBool("IsStunned", false);
        }
    }

    void Die()
    {
        if (hasDied) return; // Prevent multiple deaths
        hasDied = true;

        Debug.Log("Enemy died with layer: " + LayerMask.LayerToName(gameObject.layer));

        if (questGoal != null)
        {
            questGoal.EnemyKilled(); // Ensure this is called only once
        }
        else
            Debug.Log("There is no quest goal set.");

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        gameObject.SetActive(false);
        mobHP.SetActive(false);

        /*
        if (gameObject.tag == "Enemy")
        {
            if (questGiver.Enemy.Contains(gameObject.GetComponent<AIChase>()))
            {
                questGiver.Enemy.Remove(GetComponent<AIChase>());
                Debug.Log("Removed from list");

            }
        }
        */

        //if (questGiver != null && questGiver.Enemy.Contains(GetComponent<AIChase>()))
        //{
        //    if (questGiver.Enemy.Remove(GetComponent<AIChase>()))
        //    {
        //        Debug.Log($"{gameObject.name} removed from the quest giver's enemy list.");
        //    }


        /* Debug.Log("Enemy died with layer: " + LayerMask.LayerToName(gameObject.layer));

         // Notify the quest system that the mob has been killed
         if (questGoal != null)
         {
             questGoal.EnemyKilled(); // Pass the tag of the GameObject (gameObject)
         }
         else
             Debug.Log("There is no quest goal set.");

         // Disable enemy script and object
         GetComponent<Collider2D>().enabled = false;
         this.enabled = false;
         gameObject.SetActive(false);
         mobHP.SetActive(false); */
    }

        
    

    // Update is called once per frame
    void Update()
    {
        if (!stunned)
        {
            closestPlayer = GetClosestPlayer();

            if (closestPlayer != null)
            {
                float distance = Vector2.Distance(transform.position, closestPlayer.transform.position);
                Vector2 direction = closestPlayer.transform.position - transform.position;
                direction.Normalize();
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                if (distance < distanceBetween)
                {
                    transform.position = Vector2.MoveTowards(transform.position, closestPlayer.transform.position, speed * Time.deltaTime);
                    mobHP.SetActive(true);
                }
            }
        }


    }



    GameObject GetClosestPlayer()
    {
        GameObject closest = null;
        float minDistance = float.MaxValue;

        foreach (GameObject player in players)
        {
            //mobHP.SetActive(true);
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = player;
            }
        }

        return closest;
    }

    void MoveTowardsPlayer()
    {
        closestPlayer = GetClosestPlayer();
        if (closestPlayer != null)
        {
            float distance = Vector2.Distance(transform.position, closestPlayer.transform.position);
            if (distance < distanceBetween)
            {
                transform.position = Vector2.MoveTowards(transform.position, closestPlayer.transform.position, speed * Time.deltaTime);
                mobHP.SetActive(true);
            }
        }

    }

    // Methods to stop and resume movement and actions
    void StopAllMovementAndActions()
    {

        speed = 0;
        // Any other actions you need to stop
    }

    void ResumeMovementAndActions()
    {
        // Restore speed or other actions here if needed
        speed = 1; // Set to your desired movement speed
    }
}


