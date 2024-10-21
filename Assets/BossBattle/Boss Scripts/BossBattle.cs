using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BossBattle : MonoBehaviour, IEnemyDamage
{

    public int bossHP;
    public int currentHP;

    public Animator anim;
    public BossPhase bossPhase;
    public float startFightDistance;
    public float speed;
    public Transform currentTargetPlayer;
    public List<Transform> players = new List<Transform>();
    bool attackCooldown;


    public enum BossPhase
    {
        Idle,
        PhaseOne,
        PhaseTwo
    }

    private void Update()
    {

        switch (bossPhase)
        {
            case BossPhase.Idle:
                IdleLogic();
                break;
            case BossPhase.PhaseOne:
                PhaseOneLogic();
                break;
            case BossPhase.PhaseTwo:
                PhaseTwoLogic();
                break;
        }

    }

    public void IdleLogic()
    {
        currentTargetPlayer = DetectClosestPlayer();
        float distance = Vector2.Distance(transform.position, currentTargetPlayer.position);
        if(distance <= startFightDistance)
        {
            bossPhase = BossPhase.PhaseOne;
        }
    }

    public void PhaseOneLogic()
    {
        currentTargetPlayer = DetectClosestPlayer();
        MoveToPlayer();

        if(attackCooldown == false)
        {
            attackCooldown = true;
            Invoke("AttackCooldown", Random.Range(1, 3));
            anim.SetTrigger("Attack");
        }
    }

    void PhaseTwoLogic()
    {
        currentTargetPlayer = DetectClosestPlayer();
        MoveToPlayer();

        if (attackCooldown == false)
        {
            attackCooldown = true;
            Invoke("AttackCooldown", Random.Range(1, 3));
        }
    }

    void AttackCooldown()
    {
        attackCooldown = false;
    }

    void MoveToPlayer()
    {
        Vector3 playerPos = currentTargetPlayer.position;
        playerPos.y += 4;
        Vector2 moveDirection = (playerPos - transform.position).normalized;
        transform.position += (Vector3)moveDirection * Time.deltaTime * speed;
    }

    Transform DetectClosestPlayer()
    {
        int closestPlayer = 0;
        float closestDistance = Vector2.Distance(transform.position, players[0].position);
        for(int p = 1; p < players.Count; p++)
        {
            float newDistance = Vector2.Distance(transform.position, players[p].position);
            if (newDistance < closestDistance)
            {
                closestDistance = newDistance;
                closestPlayer = p;
            }
        }

        return players[closestPlayer];
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
    }
}
