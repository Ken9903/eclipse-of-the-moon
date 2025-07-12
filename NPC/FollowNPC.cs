using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowNPC : MonoBehaviour
{
    public Animator anim;

    public NavMeshAgent agent;

    public Transform playerFollowPoint;
    public Transform playerLookAtPoint;

    public float followDistance;
    public float stopDistance;
    public float fasterDistance;

    public bool navOn = true;

    IEnumerator CalculationDistance()
    {
        while (navOn)
        {
            stopDistance = 3;
            agent.stoppingDistance = stopDistance;

            float distance = Vector3.Distance(this.transform.position, playerFollowPoint.transform.position);
            if (distance > followDistance)
            {
                if(distance > fasterDistance)
                {
                    agent.speed = 3 * distance / 5;
                }
                else
                {
                    agent.speed = 3.5f;
                }
               
                agent.isStopped = false;
                anim.SetBool("Walk Forward", true);
                //anim.ResetTrigger("Idle");
                ChasePlayer(); 
            }
            if(distance < stopDistance)
            {
                agent.isStopped = true;
                anim.SetBool("Walk Forward", false);

                agent.velocity = Vector3.zero;
               // anim.SetTrigger("Idle");
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerFollowPoint = GameObject.Find("BodyPoint").transform;
        playerLookAtPoint = GameObject.Find("Main Camera").transform;

        agent = GetComponentInParent<NavMeshAgent>();

        StartCoroutine(CalculationDistance());
    }


    private void ChasePlayer()
    {
        Vector3 tempPos = new Vector3(playerFollowPoint.position.x, playerFollowPoint.position.y, playerFollowPoint.position.z);
        agent.SetDestination(tempPos);
        Vector3 look_At_player = new Vector3(playerLookAtPoint.position.x, this.transform.position.y, playerLookAtPoint.position.z);
        transform.LookAt(look_At_player);
    }

    
   
}
