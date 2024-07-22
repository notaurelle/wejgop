using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealer : PlayerParent
{
    private void Start()
    {
        
    }

    public override void PerformAbility()
    {
        base.PerformAbility();
        Debug.Log("Healing!");
        //Specific ability related to character
    }
}
