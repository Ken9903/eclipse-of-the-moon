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
            Instantiate(Bomb_main, this.transform.position, Bomb_main.transform.rotation); //�����̼��� ��� ������ �΋H���� ���� ������ ȸ���� �������� ����
            Debug.Log(collision.gameObject.name);
            Destroy(this.gameObject);
        }
    }
}
