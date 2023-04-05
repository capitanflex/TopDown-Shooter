using UnityEngine;
using UnityEngine.AI;

public enum ZombieType
{
        DefaultZombie, 
        TwinsMonster, 
        SlowZombie,
        Mower
}

public class EnemyController : MonoBehaviour
{
    public EnemyBehaviour enemyBehaviour;
    public EnemyParametrs enemyParametrs;

    public ZombieType zombieType;
    private GameObject player;

    public NavMeshAgent agent;
    public Animator animator;

    
    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        if (zombieType == ZombieType.DefaultZombie)
        {
            enemyBehaviour = new DefaultZombie(enemyParametrs.healthPoint, enemyParametrs.damage,
                enemyParametrs.zombieMovement,
                enemyParametrs.rangeChase, enemyParametrs.rangeAttack, enemyParametrs.rangeStopping, animator, agent);
        }
        if (zombieType == ZombieType.TwinsMonster)
        {
            enemyBehaviour = new TwinsMonster(enemyParametrs.healthPoint, enemyParametrs.damage,
                enemyParametrs.zombieMovement,
                enemyParametrs.rangeChase, enemyParametrs.rangeAttack, enemyParametrs.rangeStopping, animator, agent);
        }
        if (zombieType == ZombieType.SlowZombie)
        {
            enemyBehaviour = new SlowZombie(enemyParametrs.healthPoint, enemyParametrs.damage,
                enemyParametrs.zombieMovement,
                enemyParametrs.rangeChase, enemyParametrs.rangeAttack, enemyParametrs.rangeStopping, animator, agent);
        }
        if (zombieType == ZombieType.Mower)
        {
            enemyBehaviour = new Mower(enemyParametrs.healthPoint, enemyParametrs.damage,
                enemyParametrs.zombieMovement,
                enemyParametrs.rangeChase, enemyParametrs.rangeAttack, enemyParametrs.rangeStopping, animator, agent);
        }

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
