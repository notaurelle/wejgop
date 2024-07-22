using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParent : MonoBehaviour
{
    public bool move;
    public Sprite[] frames;

    //Movement here.

    private void Update()
    {
        if (move)
        {
            PerformAbility();
            Animate();
            //change animation.
        }
    }


    public virtual void PerformAbility()
    {
        //Input call this function.
    }

    public void Animate()
    {
        Debug.Log("animate me daddy");
    }

}
