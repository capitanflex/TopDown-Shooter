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
        enemyBehaviour = new DefaultZombie(enemyParametrs.healthPoint, enemyParametrs.damage, enemyParametrs.zombieMovement, 
            enemyParametrs.rangeChase, enemyParametrs.rangeAttack, enemyParametrs.rangeStopping, animator, agent);
        enemyBehaviour.Find();
        enemyBehaviour.Start();
    }

    protected void Update()
    {
        enemyBehaviour.EnemyCanSeePlayer();
        enemyBehaviour.ChangeState();
    }

    public void Attack()
    {
        enemyBehaviour.Attack();
    }
}
