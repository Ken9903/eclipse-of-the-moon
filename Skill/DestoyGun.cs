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

    public GameObject triggerPoint;


    void Start()
    {
        catch_Gun = GameObject.Find("Bag").GetComponent<Catch_Gun>();
        magicPrepare = GameObject.Find("MagicPrepare_L").GetComponent<MagicPrepare>();

        controllerR = GameObject.Find("RightHand Controller");
    }


    public void BackToBag()
    {
        Transform magicpos1 = GameObject.Find("MagicPos_1").GetComponent<Transform>();
        if(magicpos1.transform.childCount == 1)
        {
            magicPrepare.DestroyAll("none");
        }
        StopHaptics();

        catch_Gun.isequiped = false;

        Destroy(triggerPoint);
        Destroy(this.gameObject);
    }

    public void StopHaptics()
    {
        XRcontrollerR = GameObject.Find("RightHand Controller").GetComponent<XRController>();
        XRcontrollerR.SendHapticImpulse(0.1f, 0.1f);

        Instantiate(destroyParticle, controllerR.transform);
    }
}
