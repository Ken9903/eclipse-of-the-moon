using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStatus : MonoBehaviour
{
    public int hp;
    public int mp;  //디버그
    public float speed; //디버그
    public int attack_point;
    public int giveExp;

   // public bool enemy_is_ground = true;
    public LayerMask whatIsGround;

    NavMeshAgent enemy_Nav;
    EnemyAi enemyAi;


    private void Awake()
    {
        enemy_Nav = this.GetComponent<NavMeshAgent>();
        enemyAi = this.GetComponent<EnemyAi>();
    }
    public IEnumerator Check_Enemy_Is_Ground() 
    {
        while (true)
        {
            if (Physics.Raycast(this.transform.position, -transform.up, 1.2f, whatIsGround))
            {
               // enemy_is_ground = true;

                //Nav On
                enemy_Nav.enabled = true;
                enemyAi.enabled = true;

                yield break;
            }
            yield return null;
        }
    }
    public void SetEnemyNavOn()
    {
        // Debug.Log("스테이터스 네비온");
        //StartCoroutine(Check_Enemy_Is_Ground());
        enemy_Nav.enabled = true;
        enemyAi.enabled = true;
    }
    public void SetEnemyNavOff()
    {
        enemy_Nav.enabled = false;
        enemyAi.enabled = false;
    }


}
