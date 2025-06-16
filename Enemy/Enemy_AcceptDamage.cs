using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy_AcceptDamage : MonoBehaviour
{
    private EnemyStatus enemyStatus;
    private Animator anim;
    private EnemyAi enemyAi;

    private SphereCollider triggerCollider;

    private Player_Status player_Status;

    public float deathWaitTime;


    public bool sturned = false;
    public bool dead = false;

    public float sturnTime = 1;

    public GameObject damageUi;
    public Transform uiPoint;


    IEnumerator sturnOnOff()
    {
        sturned = true;

        yield return new WaitForSeconds(sturnTime);

        sturned = false;
    }

    IEnumerator AffectTriggerOnOff()
    {
        triggerCollider.enabled = true;
        yield return new WaitForSeconds(0.5f);
        triggerCollider.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyAi = GetComponent<EnemyAi>();
        enemyStatus = GetComponent<EnemyStatus>();

       
        anim = GetComponent<Animator>();
        
        triggerCollider = GetComponent<SphereCollider>();

        player_Status = GameObject.Find("Player").GetComponent<Player_Status>();
    }


    public void Accept_Damage_Oneshot(int damage) 
    {
        StartCoroutine(sturnOnOff());
        ShowDamageUi(damage);
       
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                anim.SetTrigger("Take Damage");
                enemyAi.sightRange = 100;

                StartCoroutine(AffectTriggerOnOff());
            }
        
            
        enemyStatus.hp = enemyStatus.hp - damage;
        Debug.Log(enemyStatus.hp);
        Check_HP_Zero();
    }
    public void Accept_Damage_Bombshot(int damage)
    {
        StartCoroutine(sturnOnOff());
        ShowDamageUi(damage);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                anim.SetTrigger("Take Damage");
                enemyAi.sightRange = 100;

                StartCoroutine(AffectTriggerOnOff()); //�ٸ� ������ ������̴� ���
            }
     

        enemyStatus.hp = enemyStatus.hp - damage;
        Debug.Log(enemyStatus.hp);
        Check_HP_Zero();
    }
    public void Accept_Damage_Rapidshot(int damage)
    {
        StartCoroutine(sturnOnOff());
        ShowDamageUi(damage);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                anim.SetTrigger("Take Damage");
                enemyAi.sightRange = 100;

                StartCoroutine(AffectTriggerOnOff()); //�ٸ� ������ ������̴� ���
            }
        

        enemyStatus.hp = enemyStatus.hp - damage;
        Debug.Log(enemyStatus.hp);
        Check_HP_Zero();
    }

    public void ShowDamageUi(int damage)
    {
        GameObject damageUI = Instantiate(damageUi, uiPoint.position,uiPoint.rotation);
        damageUI.GetComponentInChildren<Text>().text = damage.ToString();
    }

    private void Check_HP_Zero()
    {
        if(enemyStatus.hp <= 0 && dead == false) // dead�� �ѹ��� ���� �ǰ� �ϵ��� �ϴ� ��ġ. ����ġ �ߺ� ȹ�� ����.
        {
            dead = true;
            GiveExpToPlayer(); // �÷��̾�� ����ġ �ο�

            // ����̺�Ʈ
            this.GetComponent<Collider>().enabled = false;
            this.GetComponent<NavMeshAgent>().isStopped = true;
            this.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
            enemyStatus.SetEnemyNavOff();
            
            anim.SetTrigger("Die");
            
          

            
            Destroy(this.gameObject, deathWaitTime);
            
        }
    }
    private void GiveExpToPlayer()
    {
        player_Status.acquire_Exp(enemyStatus.giveExp);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyAi>().sightRange = 100;  
        }
    }
}
