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

    public bool PlayerInArea { get; private set; }
    public float bossHealthStageTwo;
    public float bossHealthStageThree;
    public HealthBar BossHealthBar;
    public List<GameObject> players;

    [SerializeField] private int maxHealth = 900;
    private bool hasDied = false;

    // animation 
    public Animator animator;

    public int attackDamage = 5;

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
        attackDamage = 5;
    
    }

    public void Die()
    {
        if (hasDied) return; // Prevents multiple deaths
        hasDied = true;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        gameObject.SetActive(false);
        BossHealthBar.gameObject.SetActive(false);
    }

    public void DetectAndAttackPlayers()
    { 
      

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
