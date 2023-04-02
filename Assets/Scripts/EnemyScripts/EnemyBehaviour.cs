using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBehaviour 
{
    protected float healthPoint;
    protected float damage;
    protected float zombieMovement;

    protected float timeAttackDelay;
    protected float timerAttackDelay;
    protected bool canLookAtPlayer;

    protected GameObject prefabZombie;

    protected float rangeChase;
    protected float rangeStopping;
    protected float rangeAttack;
    protected bool isChasing;
    protected bool isAttacking;

    public GameObject player;
    public float distanceToPlayer;
    public Vector3 directionToPlayer;

    public NavMeshAgent agent;
    public Animator animator;
    

    public EnemyBehaviour(float healthPoint, float damage, float timeAttackDelay, float zombieMovement, float rangeChase, float rangeAttack, float rangeStopping, Animator animator, NavMeshAgent agent)
    {
        this.healthPoint = healthPoint;
        this.damage = damage;
        this.timeAttackDelay = timeAttackDelay;
        this.zombieMovement = zombieMovement;
        this.rangeAttack = rangeAttack;
        this.rangeChase = rangeChase;
        this.animator = animator;
        this.agent = agent;
        this.rangeStopping = rangeStopping;
    }
    
    // public abstract void Attack();
    
    public abstract void ChangeState();

    public void Find()
    {
        player = GameObject.Find("Player");
        
    }
    
    
    // protected void AttackingDelay()
    // {
    //     if(timerAttackDelay <= 0) {
    //         canAttack = true;
    //     }
    //     else {
    //         timerAttackDelay -= Time.deltaTime;
    //         canAttack = false;
    //     }
    // }

    
}
