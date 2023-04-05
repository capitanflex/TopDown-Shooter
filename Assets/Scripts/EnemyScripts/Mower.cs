using UnityEngine;
using UnityEngine.AI;

public class Mower : EnemyBehaviour
{
    public Mower(float healthPoint, float damage, float zombieMovement, float rangeChase, float rangeAttack, float rangeStopping, Animator animator, NavMeshAgent agent) : base(healthPoint, damage, zombieMovement, rangeChase, rangeAttack, rangeStopping, animator, agent)
    {
    }

    public override void Attack()
    {
        player.GetComponent<HealthPlayer>().GetDamage(damage);
    }

    public override void GetDamage(float damage)
    {
        currentHealthPointEnemy -= damage;
    }

    public override void Start()
    {
        currentHealthPointEnemy = healthPoint;
    }

    
}
