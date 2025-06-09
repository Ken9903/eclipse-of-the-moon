using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    public int direct_mul = 1;
    public int far_mul = 1;


    public GameObject arrow;
    public Transform arrow_start_point;
    public float arrow_speed;
    public float rateSecond;

    private Player_Status player_Status;
    private Transform player;


    //존재하는 경우에만 할당.
    public ParticleSystem[] particleSystem;

    private Vector3 arrow_point = new Vector3 (0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        player_Status = GameObject.Find("Player").GetComponent<Player_Status>();
        player = GameObject.Find("Main Camera").transform;
    }

    
    

    public void direct_attack(int enemy_attack_point)
    {
        player_Status.accept_Damage_Player(enemy_attack_point * direct_mul, "direct");
    }
    public void far_attack(int enemy_attack_point)
    {
        StartCoroutine(rateShoot(enemy_attack_point));
    }

    IEnumerator rateShoot(int enemy_attack_point)
    {
        yield return new WaitForSeconds(rateSecond);

        foreach (ParticleSystem particle in particleSystem) 
        {
            particle.Play();
        }
        GameObject arrorObj = Instantiate(arrow, arrow_start_point);
        arrorObj.transform.parent = null;
        arrorObj.GetComponent<FarAttack_Damage>().damage = enemy_attack_point * far_mul;
        arrow_point = player.transform.position - arrorObj.transform.position;
        arrorObj.GetComponent<Rigidbody>().AddForce(arrow_point * arrow_speed);
    }
}
