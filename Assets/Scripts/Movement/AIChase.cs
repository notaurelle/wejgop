using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public List<GameObject> players;
    public float speed;
    public float distanceBetween;

    private GameObject closestPlayer;


    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;

    public int maxHealth = 100;
    private int currentHealth;


    public int attackDamage = 5;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("MOB DMG Player");

        if (currentHealth <= 0)
        {
            Die();
        }

    }



    private void FixedUpdate()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        //Damage them
        foreach (Collider2D player in hitPlayers)
        {
            Debug.Log("Mob hit " + player.name);
            player.GetComponent<AIChase>().TakeDamage(attackDamage);
            //value can be set in brackets TD(20) or can add public int
        }
    }



    void Die()
    {
        Debug.Log("Enemy died!");

        //Disable enemy script as they have 'died'
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

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
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
        }

    }

    GameObject GetClosestPlayer()
    {
        GameObject closest = null;
        float minDistance = float.MaxValue;

        foreach (GameObject player in players)
        {
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
