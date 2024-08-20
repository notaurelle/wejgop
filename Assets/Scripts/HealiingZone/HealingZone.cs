using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingZone : MonoBehaviour
{
    public int healingAmount = 25; // Amount of health to heal per interval
    public float healingInterval = 1f; // How often to heal (Seconds)
    public float healingRadius = 3f; // Radius of the healing zone

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Check if the collider has the tag "Wylla"
        if (col.CompareTag("Wylla"))
        {
            // Start healing coroutine for the ally that entered
            StartCoroutine(HealingCoroutine(col.gameObject));
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        // Check if the collider has the tag "Wylla"
        if (col.CompareTag("Wylla"))
        {
            // Stop healing coroutine if the ally exits the zone
            StopCoroutine(HealingCoroutine(col.gameObject));
        }
    }

    private IEnumerator HealingCoroutine(GameObject ally)
    {
        while (true)
        {
            HealAlly(ally);
            yield return new WaitForSeconds(healingInterval);
        }
    }

    private void HealAlly(GameObject ally)
    {
        // Check if the ally has the tag "Wylla"
        if (ally.CompareTag("Wylla"))
        {
            // Get the HealthBar component from the ally
            HealthBar healthBar = ally.GetComponent<HealthBar>();
            if (healthBar != null)
            {
                // Increase ally's health, but do not exceed max health
                int newHealth = Mathf.Min((int)healthBar.slider.maxValue, (int)healthBar.slider.value + healingAmount);
                healthBar.SetHealth(newHealth);
                Debug.Log("Healed " + ally.name + " to " + newHealth);
            }
            else
            {
                Debug.LogWarning("HealthBar component not found on " + ally.name);
            }
        }
        else
        {
            Debug.LogWarning(ally.name + " is not tagged as 'Wylla'");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, healingRadius);
    }
}