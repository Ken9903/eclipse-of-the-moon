using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DestoyGun : MonoBehaviour
{
    Catch_Gun catch_Gun;
    MagicPrepare magicPrepare;

    GameObject controllerR;

    XRController XRcontrollerR;

    public GameObject destroyParticle;

    public GameObject triggerPoint; //간혹가다 부모만 사라져서 트리거의 Exit함수에 missing이 나는 경우가 있음


    void Start()
    {
        catch_Gun = GameObject.Find("Bag").GetComponent<Catch_Gun>();
        magicPrepare = GameObject.Find("MagicPrepare_L").GetComponent<MagicPrepare>();

        controllerR = GameObject.Find("RightHand Controller");
    }


    public void BackToBag()
    {
        Transform magicpos1 = GameObject.Find("MagicPos_1").GetComponent<Transform>(); // �Ѱ��� ���ٴ� ���� �� ���ٴ� ���̶� 1���� ��.
        if(magicpos1.transform.childCount == 1)
        {
            magicPrepare.DestroyAll("none"); // ���� ��� źâ�� ���� ���� ä�� ���� ���ָ� źâ���� �� ���ֵ���.
        }
        StopHaptics();

        catch_Gun.isequiped = false;


        //���� ȿ������

        Destroy(triggerPoint); //간혹가다 부모만 사라져서 트리거의 Exit함수에 missing이 나는 경우가 있음
        Destroy(this.gameObject);
    }
    




    public void StopHaptics()
    {
        XRcontrollerR = GameObject.Find("RightHand Controller").GetComponent<XRController>();
        XRcontrollerR.SendHapticImpulse(0.1f, 0.1f); //�� ������ ���� �ַ� ������ ��ƽ ��.

        Instantiate(destroyParticle, controllerR.transform);
    }
}
