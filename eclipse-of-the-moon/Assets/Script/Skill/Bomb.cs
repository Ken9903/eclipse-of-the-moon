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
        controllerLPos = GameObject.Find("LeftHand Controller").GetComponent<Transform>(); // ���� �ߺ��Ǿ� ���� ���� ����.
        catch_Stone = GameObject.Find("Bag").GetComponent<Catch_Stone>();
    }
    void Update()
    {
        if (controllerL.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool pressed))
        {
            if(pressed == true && used == false && isSelect == true) //isselect�� ��ü
            {
                used = true;
                //��¥ ������ �ߵ� �Ǳ� ������ ������ ���� �տ� ������ ������ ��� iseq
                prepareMagic();
            }
        }
    }


    void prepareMagic()
    {
        EyeTrans = GameObject.Find("EyeTrans").GetComponent<Transform>();

        GameObject icebomb_Collider = Instantiate(Bomb_Logic_Collider); // ���� Ÿ�� ����

        Bomb_Logic_Col bomb_Logic_Col = icebomb_Collider.GetComponent<Bomb_Logic_Col>();
        bomb_Logic_Col.Bomb = Bomb_effect; //effect����

        icebomb_Collider.transform.SetParent(EyeTrans, false);

        Instantiate(Pusheffect, controllerLPos);

        Destroy(this.gameObject);

    }

    public void SetisSelect()
    {
        isSelect = true;
    }

   


   
}
