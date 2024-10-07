using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossStages { One, Two, Three, Dead }
public class BossBattle : MonoBehaviour
{
    public bool startBossBattle; //Set this true once you've finished dialogue etc. 

    public BossStages currentBossStage;

    [Header("Boss Health")]
    public float bossHealth; //TEMPORARY - ADD BOSS HEALTHBAR SCRIPT HERE AND GET THE HEALTH VALUE


    public float bossHealthStageTwo;
    public float bossHealthStageThree;
    public HealthBar BossHealthBar;
    public List<GameObject> players;
    public float speed;
    public float distanceBetween;

    private GameObject closestPlayer;


    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;


    [SerializeField] private int maxHealth = 900;
    private bool hasDied = false;

    // animation 
    public Animator animator;

    public int attackDamage = 5;
    public int decreaseDamage = 4;
    public bool attackDecreased = false;

    //stun properties 
    public bool stunned = false;
    public float stunDuration = 2f;

    void Start()

    {
        bossHealth = maxHealth;
        BossHealthBar.SetMaxHealth(maxHealth);
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if (startBossBattle)
        {
            HandleBossStage();
        }
    }


    public void HandleBossStage()
    {
        if (bossHealth < bossHealthStageTwo && currentBossStage == BossStages.One)
            currentBossStage = BossStages.Two;

        if (bossHealth < bossHealthStageThree && currentBossStage == BossStages.Two)
            currentBossStage = BossStages.Three;

        if (bossHealth <= 0)
            currentBossStage = BossStages.Dead;

        switch (currentBossStage)
        {
            case BossStages.One:

                DetectAndAttackPlayers();

                break;
            case BossStages.Two:

                DetectAndAttackPlayers();
                SpawnEnemies();

                break;
            case BossStages.Three:

                AcidRain();

                break;

            case BossStages.Dead:

                //handle dead stuff
                Die();


                    break;
        }

    }

    void attackPlayer()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        //Damage them
        foreach (Collider2D player in hitPlayers)
        {
            Debug.Log("Boss hit " + player.name);
            //Short hand for if statement
            player.GetComponent<PlayerParent>().TakeDamage(attackDecreased == true ? attackDamage - decreaseDamage : attackDamage);


            //value can be set in brackets TD(20) or can add public int
        }
    }

    public void Die()
    {
        if (hasDied) return; // Prevent multiple deaths
        hasDied = true;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        gameObject.SetActive(false);
        BossHealthBar.gameObject.SetActive(false);
    }

    public void DetectAndAttackPlayers()
    { 
        //Logic from AI Chase.
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
                    //BossHealth.SetActive(true);

                    if (distance < attackRange)
                    {
                        attackPlayer();
                    }
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

            }
        }

    }




    public void SpawnEnemies()
    {
        //Spawn a wave of enemies in random spots on the map.
        //Limit the amount of enemies
        //If all enemies are dead, spawn another wave

        Debug.Log("Spawning enemies");
    }

    public void AcidRain()
    {
        //Area of effect / damage over time
        //Reuse the spawning of enemies (random spot)
        //Instead of enemies, spawn acid rain prefabs.
        //They would have the damage over time script.
        //Destroy them after a certain amount of time.

        Debug.Log("Spawning acid rain");
    }
}
