using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDPS : PlayerParent
{

    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("impact registered"); 
    } 
    public override void PerformAbility()
    {
        base.PerformAbility();

        Debug.Log("DPS!");
    }


}
