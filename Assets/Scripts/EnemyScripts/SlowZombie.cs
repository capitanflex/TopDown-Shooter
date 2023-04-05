using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlowZombie : EnemyBehaviour
{
    public SlowZombie(float healthPoint, float damage, float zombieMovement, float rangeChase, float rangeAttack, float rangeStopping, Animator animator, NavMeshAgent agent) : base(healthPoint, damage, zombieMovement, rangeChase, rangeAttack, rangeStopping, animator, agent)
    {
    }
    
    public override void Start()
    {
        currentHealthPointEnemy = healthPoint;
    }

    

    public override void Attack()
    {
        player.GetComponent<HealthPlayer>().GetDamage(damage);
    }
    
    public override void GetDamage(float damage)
    {
        currentHealthPointEnemy -= damage;
    }
}
