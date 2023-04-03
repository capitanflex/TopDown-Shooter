using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBehaviour 
{
    protected float healthPoint;
    protected float currentHealthPointEnemy;
    public float damage;
    protected float zombieMovement;
    
    protected bool canLookAtPlayer;
    protected RaycastHit hit;
    protected float rayCastDistance = 500;

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
    

    public EnemyBehaviour(float healthPoint, float damage, float zombieMovement, float rangeChase, float rangeAttack, float rangeStopping, Animator animator, NavMeshAgent agent)
    {
        this.healthPoint = healthPoint;
        this.damage = damage;
        this.zombieMovement = zombieMovement;
        this.rangeAttack = rangeAttack;
        this.rangeChase = rangeChase;
        this.animator = animator;
        this.agent = agent;
        this.rangeStopping = rangeStopping;
    }
    
    public abstract void Attack();
    public abstract void ChangeState();
    public abstract void EnemyCanSeePlayer();
    public abstract void GetDamage(float damage);

    public abstract void Start();

    public void Find()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
