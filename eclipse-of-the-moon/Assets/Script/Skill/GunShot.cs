using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    private Transform weapon_appear_pos;
    public GameObject gunshot_appear;  //동적 할당으로 모습 변경 여지 있음.
    // Start is called before the first frame update
    void Start()
    {
        weapon_appear_pos = GameObject.Find("Weapon_appear_pos").GetComponent<Transform>();
        GameObject gunshot = Instantiate(gunshot_appear, weapon_appear_pos.transform);
        gunshot.transform.SetParent(weapon_appear_pos);
    }

}
