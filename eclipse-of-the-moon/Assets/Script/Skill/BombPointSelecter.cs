using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPointSelecter : MonoBehaviour
{
    public GameObject Bomb_main;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Skill")
        {
            Instantiate(Bomb_main, this.transform.position, Bomb_main.transform.rotation); //로테이션은 어느 각도로 부딫혀도 원래 폭발의 회전값 유지위해 설정
            Debug.Log(collision.gameObject.name);
            Destroy(this.gameObject);
        }
    }
}
