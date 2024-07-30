using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerParent : MonoBehaviour
{
    public bool move; // this doesnt make layer move it only sets this active
    public Sprite[] frames;
    private Vector2 moveInputValue;
    AIChase aiChase;
    //Movement here.
   

    public virtual void TakeDamage(int Damage)
    {

    }




    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other GameObject has the tag "Enemy"
        if (other.CompareTag("Enemy"))
        {
            aiChase.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Optional: Unfreeze the Rigidbody2D when the enemy exits the trigger
        if (other.CompareTag("Enemy"))
        {
            aiChase.enabled = true;
        }
    }
    */







private void Update()
    {

        if (move)
        {
            PerformAbility();
            //Animate();
            //change animation.
        }

        MoveLogic();
    }

    private void OnMove(InputValue value)
    {
        Debug.Log("plz work");
        moveInputValue = value.Get<Vector2>(); 
    }

    private void MoveLogic()
    {
        transform.Translate(moveInputValue * Time.deltaTime * 5);
    }


    public virtual void PerformAbility()
    {
        //Input call this function. for abilities 
    }

    public void Animate()
    {
        Debug.Log("animate me daddy");
    }

}
