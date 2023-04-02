using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class DefaultZombie : EnemyBehaviour
{
    public DefaultZombie(float healthPoint, float damage, float timeAttackDelay, float zombieMovement, float rangePatrolling, float rangeAttack,float rangeStopping, Animator animator, NavMeshAgent agent)
        : base(healthPoint, damage, timeAttackDelay, zombieMovement, rangePatrolling, rangeAttack, rangeStopping, animator, agent){}

   
    // public override void Attack()
    // {
    //     if (canAttack)
    //     {
    //         AttackingDelay();
    //     }
    // }

    public override void ChangeState()
    {
        
        distanceToPlayer = Vector3.Distance(player.transform.position, agent.transform.position);
        directionToPlayer = new Vector3(player.transform.position.x - agent.transform.position.x, 
            player.transform.position.y - agent.transform.position.y, 
            player.transform.position.z - agent.transform.position.z);

        if (distanceToPlayer <= rangeChase)
        {
            isChasing = true;
            
            if (distanceToPlayer <= rangeAttack + 0.5f) { isAttacking = true; isChasing = false;}
            else { isAttacking = false; }
        }
        else if(distanceToPlayer >= rangeStopping)
        {
            isChasing = false;
        }

        if (isChasing) { EnemyChasing(); }
        if (isAttacking) { EnemyAttacking(); }
        if (!isAttacking && !isChasing){ EnemyStay();}
    }
    
    private void EnemyChasing()
    {
        agent.SetDestination(player.transform.position);
        agent.speed = zombieMovement;
        animator.SetBool("isStaying", false);
        animator.SetBool("isChasing", true);
        animator.SetBool("isAttacking", false);
        agent.isStopped = false;
    }
    
    private void EnemyAttacking()
    {
        agent.stoppingDistance = rangeAttack;
        animator.SetBool("isAttacking", true);
        animator.SetBool("isChasing", false);
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        targetRotation.x = 0f;
        targetRotation.z = 0f;
        agent.transform.rotation = Quaternion.Lerp(agent.transform.rotation ,targetRotation, 10);
    }
    
    private void EnemyStay()
    {
        animator.SetBool("isStaying", true);
        animator.SetBool("isChasing", false);
        agent.isStopped = true;
    }
}