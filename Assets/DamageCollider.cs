using UnityEngine;

public class DamageCollider : MonoBehaviour
{

    public int damageAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ally" || collision.gameObject.tag == "Wylla")
        {
            collision.gameObject.GetComponent<PlayerParent>().TakeDamage(damageAmount);
        }
    }

}
