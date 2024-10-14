using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour

{
    public HealthBar BossHealthBar; 
    public int health = 900;
    public GameObject deathEffect;
    public bool isInvulnerable = false;
    private bool hasDied = false; 

    public void TakeDamage(int damage)
    {
        if (isInvulnerable)
            return;

        health -= damage;

        if (health <= 500)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true); //Is enraged is Phase 2
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if(hasDied) return; // Prevents multiple deaths
        hasDied = true;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        gameObject.SetActive(false);
        BossHealthBar.gameObject.SetActive(false);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
