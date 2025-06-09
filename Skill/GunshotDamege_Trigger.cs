using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GunshotDamege_Trigger : MonoBehaviour
{
    private Enemy_AcceptDamage enemy_AcceptDamage;
    public float damageDot = 1;

    public Player_Status status;
    public int damage; //�÷��̾�� ���ݷ¿� ����ϳ� ���� ���ؼ� �ִ� �ɷ� ���� ����

    public GameObject shot_after;

    public float impulse_power = 1.0f;

    private void Start()
    {
        status = GameObject.Find("Player").GetComponent<Player_Status>();
        damage = (int)(damageDot * status.attackPoint);
    }




    private void OnCollisionEnter(Collision collision)
    {
        //�����̺�Ʈ

        if (collision.gameObject.tag == "Enemy")
        {
            //������ �޽���
            GameObject target_Enemy = collision.gameObject;
            enemy_AcceptDamage = target_Enemy.GetComponent<Enemy_AcceptDamage>();
            enemy_AcceptDamage.Accept_Damage_Oneshot(damage);

            //�˹�
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                Vector3 nockBack_vector = hit.point - this.transform.position;


                EnemyStatus enemyStatus = target_Enemy.GetComponent<EnemyStatus>();
                enemyStatus.SetEnemyNavOff();

                target_Enemy.GetComponent<Rigidbody>().AddForce(nockBack_vector.normalized * impulse_power, ForceMode.Impulse);

                enemyStatus.SetEnemyNavOn();
                Debug.Log("������ �׺��");

            }

        }
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Skill")  
        {
            Instantiate(shot_after, this.transform.position, this.transform.rotation);
            Debug.Log(collision.gameObject.name);
            Destroy(this.gameObject);
        }
    }
    


}



