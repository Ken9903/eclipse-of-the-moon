using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class Catch_Stone : MonoBehaviour
{
    public XRController controllerL;

    public Transform stone_init_pointL;

    public GameObject stone;

    public GameObject[] stoneList = new GameObject[3];

    public bool isequiped = false;
    public bool magic_ing = false;





    private void OnTriggerExit(Collider other)
    {
        if (isequiped == false && magic_ing == false && stone != null)
        {
            if (other.gameObject.name == "LeftHandTrans")
            {
                if (controllerL.inputDevice.TryGetFeatureValue(CommonUsages.grip, out float gripTargetR))
                {
                    if (gripTargetR > 0.9)
                    {
                        stone.GetComponent<Rigidbody>().isKinematic = true;
                        stone.GetComponent<Transform>().position = new Vector3(0, 0, 0);
                        Instantiate(stone, stone_init_pointL);
                        stone = null;
                        isequiped = true;
                    }
                }
            }
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if(stone == null) // enter가 stay보다 일찍 호출
        {
            if(other.tag == "Stone")
            {
                if (other.gameObject.name.Contains("IceStone"))  //instantiate해서 나온 물체는 클론이라는 이름이 붙음
                {
                    stone = stoneList[0];
                }// 만들어지는 대로 쭉쭉 늘리기


                other.GetComponent<DetachStone>().destroy();
            }
        }
    }
}
