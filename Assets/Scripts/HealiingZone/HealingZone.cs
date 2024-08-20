using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingZone: MonoBehaviour
{
    public int healingAmount = 25; //Amount of health to heal per interval 
    public float healingInterval = 1f; // How often to heal (Seconds)
    public float healingRadius = 3f;

    private PlayerHealer healer; // reference to specific healer  

   

    private void Start()
    {
        GameObject healerObject = GameObject.Find("Player1 (Healer)/Wylla"); 
        if (healerObject != null)
        {
            healer = healerObject.GetComponent<PlayerHealer>(); 
            if (healer == null)
            {
                Debug.LogError("PlayerHealer component not found on Player 1 (Healer)/Wylla");
            }
        }
        else
        {
            Debug.LogError("Player1 (Healer)/Wylla GameObject not found.");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == healer)
        {
            StartCoroutine(HealingWithinZone());
        }
            
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject == healer)
        {
            StopCoroutine(HealingWithinZone());
        }
            
    }

    private IEnumerator HealingWithinZone()
    {
        while (true)
        {
            //Ensure the healer is stilll valid 
            if (healer != null)
            {
                HealWylla(healer);
            }
            else
            {
                Debug.LogWarning("Healer reference is missing");
                yield break; // Exit coroutine if healer is no longer valid 
            }
            //Wait for the specified Interval before healing again 
            yield return new WaitForSeconds(healingInterval);
        }
    }

    private void HealWylla(PlayerHealer target)
    {
        HealthBar healthBar = target.GetComponent<HealthBar>(); 
        if (healthBar != null)
        {
            // Increase health but do not exceed max health
            int newHealth = Mathf.Min(target.maxHealth, target.currentHealth + healingAmount);
            target.currentHealth = newHealth; // Directly modify currentHealth
            target.healthBar.SetHealth(newHealth); // Update health bar
            Debug.Log("Healed " + target.gameObject.name + " to " + newHealth);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, healingRadius);
    }

}
   
