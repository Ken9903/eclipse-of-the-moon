using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_BombShot : MonoBehaviour
{
    Transform shot_start_point;

    public GameObject BombBullet;
    public float bullet_speed;
    // Start is called before the first frame update
    void Start()
    {
        shot_start_point = GameObject.Find("shot_start_point").GetComponent<Transform>();
        GameObject bullet = Instantiate(BombBullet, shot_start_point.position, shot_start_point.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bullet_speed);
    }

    
    
}
