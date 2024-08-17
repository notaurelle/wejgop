using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIChase : MonoBehaviour
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


    public int attackDamage = 5;

    //timer
    public float Timer;
    public float attackTimer = 3;

    //stun properties 
    public bool stunned = false;
    public float stunDuration = 2f;

    public HealthBar healthBar;

    // quest tingz
    public QuestGoal questGoal;
    public int ID { get; set; }
    // public Quest quest; //reference to quest 

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        ID = 0;
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
        }
    }

    void attackPlayer()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        //Damage them
        foreach (Collider2D player in hitPlayers)
        {
            Debug.Log("Mob hit " + player.name);
            player.GetComponent<PlayerParent>().TakeDamage(attackDamage);
            //value can be set in brackets TD(20) or can add public int
        }
    }

    public void ApplyStun()
    {
        if (!stunned)
        {
            stunned = true;
            StartCoroutine(StunCoroutine());
        }
    }

    private IEnumerator StunCoroutine()
    {
        //Add visual and audio
        yield return new WaitForSeconds(stunDuration);

        stunned = false;
    }

    void Die()
    {
        /* Debug.Log("Enemy died!");

         // Notify the quest system that the mob has been killed 
         if(questGoal != null)
         {
             questGoal.EnemyKilled(gameObject);
         }

         //Disable enemy script as they have 'died'
         GetComponent<Collider2D>().enabled = false;
         this.enabled = false;
         gameObject.SetActive(false);
         mobHP.SetActive(false); */

        Debug.Log("Enemy died with layer: " + LayerMask.LayerToName(gameObject.layer));

        // Notify the quest system that the mob has been killed
        if (questGoal != null)
        {
            questGoal.EnemyKilled(); // Pass the tag of the GameObject (gameObject)
        }

        // Disable enemy script and object
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        gameObject.SetActive(false);
        mobHP.SetActive(false);
    }


        // Update is called once per frame
        void Update()
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
                    //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
                    mobHP.SetActive(true);
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
    }

