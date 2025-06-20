using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bomb_Damage_Skill : MonoBehaviour
{
    private Enemy_AcceptDamage enemy_AcceptDamage;
    private Player_Status player_Status;
    SkillManager skillManager;

    GameObject target_Enemy;

    public GameObject skillObjForLevel;

    public int basicDamage = 2;
    public float damageDot;
    int damage;

    private bool trigger_enable = true;

    public float DestroyTime = 3;

    IEnumerator Trigger_life()  //스킬발동후에 트리거 접속하는 경우 방지
    {
        yield return new WaitForSeconds(0.1f);
        trigger_enable = false;
        yield return new WaitForSeconds(DestroyTime);
        Destroy(this.gameObject);
    }

    private void Start()
    {
        player_Status = GameObject.Find("Player").GetComponent<Player_Status>();
        skillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>();
        damageDot = basicDamage + (0.1f * skillManager.useAble[skillObjForLevel]);
        damage = (int)(damageDot * player_Status.attackPoint);
    }

    private void Awake()
    {
        StartCoroutine(Trigger_life());
    }


    private void OnTriggerEnter(Collider other) // 충돌 갯수만큼 발동되어서 굳이 리스트 처리안해줘도됌.
    {
        if (trigger_enable == true)
        {
            if (other.gameObject.tag == "Enemy")
            {
                trigger_enable = false;
                target_Enemy = other.gameObject;
                enemy_AcceptDamage = target_Enemy.GetComponent<Enemy_AcceptDamage>();

                enemy_AcceptDamage.Accept_Damage_Bombshot(damage); //데미지 메시지

                //넉백
                EnemyStatus enemyStatus = target_Enemy.GetComponent<EnemyStatus>();
                enemyStatus.SetEnemyNavOff();

                Vector3 nockBack_vector = target_Enemy.transform.position - this.transform.position;
                target_Enemy.GetComponent<Rigidbody>().AddForce(nockBack_vector.normalized * 50, ForceMode.Impulse);
                target_Enemy.GetComponent<Rigidbody>().AddExplosionForce(700f, transform.position, 20f, 1500f);
                //enemyStatus.enemy_is_ground = false;

                enemyStatus.SetEnemyNavOn();

            }
        }
    }



}

