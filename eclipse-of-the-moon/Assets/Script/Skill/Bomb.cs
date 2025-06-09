using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class Bomb : MonoBehaviour        
{
    private Transform EyeTrans;
    public GameObject Bomb_Logic_Collider;

    public GameObject Bomb_effect;

    public XRController controllerL;
    public Transform controllerLPos;

    public GameObject Pusheffect;

    public bool isSelect;


    Catch_Stone catch_Stone;
    bool used = false;
    // Start is called before the first frame update
    void Start()
    {
        controllerL = GameObject.Find("LeftHand Controller").GetComponent<XRController>();
        controllerLPos = GameObject.Find("LeftHand Controller").GetComponent<Transform>(); // 위와 중복되어 개선 여지 있음.
        catch_Stone = GameObject.Find("Bag").GetComponent<Catch_Stone>();
    }
    void Update()
    {
        if (controllerL.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool pressed))
        {
            if(pressed == true && used == false && isSelect == true) //isselect로 교체
            {
                used = true;
                //진짜 마법이 발동 되기 전까지 아직은 돌이 손에 장착된 것으로 취급 iseq
                prepareMagic();
            }
        }
    }


    void prepareMagic()
    {
        EyeTrans = GameObject.Find("EyeTrans").GetComponent<Transform>();

        GameObject icebomb_Collider = Instantiate(Bomb_Logic_Collider); // 폭발 타입 전달

        Bomb_Logic_Col bomb_Logic_Col = icebomb_Collider.GetComponent<Bomb_Logic_Col>();
        bomb_Logic_Col.Bomb = Bomb_effect; //effect전달

        icebomb_Collider.transform.SetParent(EyeTrans, false);

        Instantiate(Pusheffect, controllerLPos);

        Destroy(this.gameObject);

    }

    public void SetisSelect()
    {
        isSelect = true;
    }

   


   
}
