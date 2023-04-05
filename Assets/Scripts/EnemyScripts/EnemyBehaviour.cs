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
    protected bool isDead;

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
    public abstract void GetDamage(float damage);
    public abstract void Start();
    
    public void EnemyCanSeePlayer()
    {
        if (Physics.Raycast(agent.transform.position, directionToPlayer, out hit, rayCastDistance))
        {
            if (hit.collider.gameObject.CompareTag("Player") && !isDead)
            {
                canLookAtPlayer = true;
            }
        }
    }
    
    public void ChangeState()
    {
        distanceToPlayer = Vector3.Distance(player.transform.position, agent.transform.position);
        directionToPlayer = new Vector3(player.transform.position.x - agent.transform.position.x, 
            player.transform.position.y - agent.transform.position.y, 
            player.transform.position.z - agent.transform.position.z);

        if (distanceToPlayer <= rangeChase && canLookAtPlayer)
        {
            isChasing = true;
            
            if (distanceToPlayer <= rangeAttack + 0.5f) { isAttacking = true; isChasing = false;}
            else { isAttacking = false; }
        }
        else if(distanceToPlayer >= rangeStopping)
        {
            isChasing = false;
            canLookAtPlayer = false;
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

    protected void EnemyAttacking()
    {
        agent.Stop();
        agent.stoppingDistance = rangeAttack;
        animator.SetBool("isAttacking", true);
        animator.SetBool("isChasing", false);
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
        targetRotation.x = 0f;
        targetRotation.z = 0f;
        agent.transform.rotation = Quaternion.Lerp(agent.transform.rotation ,targetRotation, 50);
    }

    private void EnemyStay()
    {
        animator.SetBool("isStaying", true);
        animator.SetBool("isChasing", false);
        agent.isStopped = true;
    }

    private void Death()
    {
        animator.SetBool("isStaying", false);
        animator.SetBool("isChasing", false);
        animator.SetBool("isAttacking", false);
        animator.SetBool("isDead", true);
        isDead = true;
        zombieMovement = 0;
    }

    public void Find()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
}
