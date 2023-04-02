using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EnemyBehaviour enemyBehaviour;
    public EnemyParametrs enemyParametrs;

    private GameObject player;

    public NavMeshAgent agent;
    public Animator animator;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
        enemyBehaviour = new DefaultZombie(enemyParametrs.healthPoint, enemyParametrs.damage, enemyParametrs.timeAttackDelay,
            enemyParametrs.zombieMovement, enemyParametrs.rangeChase, enemyParametrs.rangeAttack, enemyParametrs.rangeStopping, animator, agent);
        
    }

    protected void Update()
    {
        enemyBehaviour.Find();
        enemyBehaviour.ChangeState();
    }
}
