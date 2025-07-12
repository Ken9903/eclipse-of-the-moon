using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFIre_Damage_Trigger : MonoBehaviour
{
    private Enemy_AcceptDamage enemy_AcceptDamage;
    public float damageDot = 0.3f;
    int damage;
    SkillManager skillManager;

    public Player_Status status;
    public GameObject skillObjForLevel;

    private void Start()
    {
        status = GameObject.Find("Player").GetComponent<Player_Status>();
        skillManager = GameObject.Find("SkillManager").GetComponent<SkillManager>();
        damageDot = 0.3f + skillManager.useAble[skillObjForLevel] * 0.03f;
        damage = (int)(damageDot * status.attackPoint);

    }


    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Enemy")
        {
            GameObject target_Enemy = other;
            enemy_AcceptDamage = target_Enemy.GetComponent<Enemy_AcceptDamage>();
            enemy_AcceptDamage.Accept_Damage_Rapidshot(damage);
        }
    }
}
