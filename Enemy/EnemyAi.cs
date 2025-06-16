using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    private Animator anim;

    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public EnemyStatus enemyStatus;

    public Enemy_Attack enemy_Attack;
    public string enemy_attack_type;

    public Enemy_AcceptDamage enemy_AcceptDamage;

    //Patroling
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks = 1;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    private void Awake()
    {
        anim = GetComponent<Animator>();

        player = GameObject.Find("BodyPoint").transform;
        agent = GetComponentInParent<NavMeshAgent>(); // go
        agent.stoppingDistance = attackRange;

        enemy_AcceptDamage = GetComponent<Enemy_AcceptDamage>();
        
    }


    void Update()
    {
        
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange && agent.enabled == true)
        {
            Idle();
        }
        if (playerInSightRange && !playerInAttackRange && agent.enabled == true)
        {
            ChasePlayer();
        }
        if (playerInSightRange && playerInAttackRange && agent.enabled == true)
        {
            AttackPlayer();
        }
    }
       
    
    private void Patroling()
    {
        agent.isStopped = false;
        anim.SetBool("Walk Forward", true);
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }

        if (walkPointSet )
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint; 

        if (distanceToWalkPoint.magnitude < 1f) 
        {
            walkPointSet = false;
        }
    }
    private void Idle()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            anim.ResetTrigger("Idle");
        }
        else
        {
            anim.SetTrigger("Idle");
        }
        anim.SetBool("Walk Forward", false);
        agent.ResetPath();
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 1f, whatIsGround))
        {
            walkPointSet = true;
        }
           
    }

    private void ChasePlayer()
    {
        agent.isStopped = false;
        anim.SetBool("Walk Forward", true);
        agent.SetDestination(player.position);
        Vector3 look_At_player = new Vector3(player.position.x, this.transform.position.y, player.position.z);
        transform.LookAt(look_At_player);
    }

    private void AttackPlayer() 
    {
        Vector3 look_At_player = new Vector3(player.position.x, this.transform.position.y, player.position.z);
        transform.LookAt(look_At_player);

        if (!alreadyAttacked && enemy_AcceptDamage.dead == false && enemy_AcceptDamage.sturned == false) 
        {
            ///Attack code here
            if(enemy_attack_type == "direct") 
            {
                enemy_Attack.direct_attack(enemyStatus.attack_point);
            }
            else if(enemy_attack_type == "far") 
            {
                enemy_Attack.far_attack(enemyStatus.attack_point);
            }

            ///End of attack code
            anim.SetTrigger("Attack");

            Invoke("Stop_Destination", 0.5f); //���� ������ �� �����ͼ� ���߱�
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks); //��Ÿ�� ����
        }
    }
   private void Stop_Destination()
    {
        if(agent.enabled == true) // if������ ����ó�� addforce�� ���� �������� ����Ǵ°� ����
        {
            agent.velocity = Vector3.zero;
            agent.isStopped = true;
            agent.ResetPath();

            anim.SetBool("Walk Forward", false);
        }
      
    }
    private void ResetAttack() //���� ��Ÿ��
    {
        alreadyAttacked = false;
    }

    
}
