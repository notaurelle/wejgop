using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Godrick_Weapon : MonoBehaviour
{
    public int attackDamage = 10;
    public float attackRange = 1f;
    public int enragedAttackDamage = 30;
    public Vector3 attackOffset;
    public LayerMask attackMask;

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null )
        {
            colInfo.GetComponent<PlayerHealer>().TakeDamage(attackDamage);
        }
    }

    public void EnragedAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealer>().TakeDamage(attackDamage);
        }
    }

}
