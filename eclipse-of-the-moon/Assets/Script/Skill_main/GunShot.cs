using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    private Transform weapon_appear_pos;
    public GameObject gunshot_appear;  //���� �Ҵ����� ��� ���� ���� ����.
    // Start is called before the first frame update
    void Start()
    {
        weapon_appear_pos = GameObject.Find("Weapon_appear_pos").GetComponent<Transform>();
        GameObject gunshot = Instantiate(gunshot_appear, weapon_appear_pos.transform);
        gunshot.transform.SetParent(weapon_appear_pos);
    }

}
