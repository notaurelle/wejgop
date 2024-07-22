using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDPS : PlayerParent
{
    public override void PerformAbility()
    {
        base.PerformAbility();

        Debug.Log("DPS!");
    }
}
