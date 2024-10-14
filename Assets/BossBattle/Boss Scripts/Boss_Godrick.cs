using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Godrick : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f; // flips on z axis

        if (transform.position.x > player.position.x && isFlipped) //checks player pos and if the boss x coordinate is greater than player pos and if boss is flipped
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;  
        }

        else if (transform.position.x > player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }
}
