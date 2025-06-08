using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bomb_Damage_Trigger : MonoBehaviour
{
    private Enemy_AcceptDamage enemy_AcceptDamage;
    private Player_Status player_Status;

    GameObject target_Enemy;

    int damageDot = 5;
    int damage;

    private bool trigger_enable = true;

    IEnumerator Trigger_life()  //��ų�ߵ��Ŀ� Ʈ���� �����ϴ� ��� ����
    {
        yield return new WaitForSeconds(0.1f);
        trigger_enable = false;
        yield return new WaitForSeconds(3.0f); 
        Destroy(this.gameObject);
    }

    private void Start()
    {
        player_Status = GameObject.Find("Player").GetComponent<Player_Status>();
        damage = (int)(damageDot * player_Status.attackPoint);
    }

    private void Awake()
    {
        StartCoroutine(Trigger_life());
    }


    private void OnTriggerEnter(Collider other) // �浹 ������ŭ �ߵ��Ǿ ���� ����Ʈ ó�������൵��.
    {
        if (trigger_enable == true)
        {
            if (other.gameObject.tag == "Enemy")
            {
                trigger_enable = false;
                target_Enemy = other.gameObject;
                enemy_AcceptDamage = target_Enemy.GetComponent<Enemy_AcceptDamage>();

                enemy_AcceptDamage.Accept_Damage_Bombshot(damage); //������ �޽���

                //�˹�
                EnemyStatus enemyStatus = target_Enemy.GetComponent<EnemyStatus>();
                enemyStatus.SetEnemyNavOff();

                Vector3 nockBack_vector = target_Enemy.transform.position - this.transform.position;
                target_Enemy.GetComponent<Rigidbody>().AddForce(nockBack_vector.normalized * 30 , ForceMode.Impulse);
                target_Enemy.GetComponent<Rigidbody>().AddExplosionForce(700f, transform.position, 20f, 1500f);
                //enemyStatus.enemy_is_ground = false;

                enemyStatus.SetEnemyNavOn();

            }
        }
    }

   

}
