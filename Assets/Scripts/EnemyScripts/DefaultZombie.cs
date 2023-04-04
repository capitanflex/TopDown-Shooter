using UnityEngine;
using UnityEngine.AI;

public class DefaultZombie : EnemyBehaviour
{
    public DefaultZombie(float healthPoint, float damage, float zombieMovement, float rangePatrolling, float rangeAttack,float rangeStopping, Animator animator, NavMeshAgent agent)
        : base(healthPoint, damage, zombieMovement, rangePatrolling, rangeAttack, rangeStopping, animator, agent){}
    
    public override void GetDamage(float damage)
    {
        currentHealthPointEnemy -= damage;
    }

    public override void Start()
    {
        currentHealthPointEnemy = healthPoint;
    }

    

    public override void Attack()
    {
        player.GetComponent<HealthPlayer>().GetDamage(damage);
    }
}