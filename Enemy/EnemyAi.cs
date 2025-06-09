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

    // Update is called once per frame
    void Update()
    {
        
            //Check for sight and attack range
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if (!playerInSightRange && !playerInAttackRange && agent.enabled == true)
            {
                idle();
                //Patroling();
                //필요시 패트롤링
            }
            if (playerInSightRange && !playerInAttackRange && agent.enabled == true)
            {
                ChasePlayer();
            }
            if (playerInAttackRange && playerInSightRange && agent.enabled == true)
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

        Vector3 distanceToWalkPoint = transform.position - walkPoint; //목적지까지의 벡터 계산

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f) //백터의 길이가 1보다 작을 때
        {
            walkPointSet = false;
        }
    }
    private void idle()
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
        //Calculate random point in range 현재는 이동 범위 지정이 안되있음. 패트롤이 자유분방함.
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 1f, whatIsGround))//공중이 아닌 경우 경로지정 허가.
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

    private void AttackPlayer() //경직이나 죽을 때 막아야함
    {
        Vector3 look_At_player = new Vector3(player.position.x, this.transform.position.y, player.position.z);
        transform.LookAt(look_At_player);

        if (!alreadyAttacked && enemy_AcceptDamage.dead == false && enemy_AcceptDamage.sturned == false) 
        {
            ///Attack code here
            if(enemy_attack_type == "direct") //근거리
            {
                enemy_Attack.direct_attack(enemyStatus.attack_point);
            }
            else if(enemy_attack_type == "far") //원거리
            {
                enemy_Attack.far_attack(enemyStatus.attack_point);
            }

            ///End of attack code
            anim.SetTrigger("Attack");

            Invoke("Stop_Destination", 0.5f); //좀더 깊숙한 곳 까지와서 멈추기
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks); //쿨타임 설정
        }
    }
   private void Stop_Destination()
    {
        if(agent.enabled == true) // if조건은 예외처리 addforce를 위해 꺼버리고 실행되는걸 방지
        {
            agent.velocity = Vector3.zero;
            agent.isStopped = true;
            agent.ResetPath();

            anim.SetBool("Walk Forward", false);
        }
      
    }
    private void ResetAttack() //공격 쿨타임
    {
        alreadyAttacked = false;
    }

    
}
