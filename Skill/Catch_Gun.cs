using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class Catch_Gun : MonoBehaviour
{
    public XRController controllerR;

    public Transform gun_init_pointR;

    public GameObject gun;

    public bool isequiped = false;



    private void OnTriggerStay(Collider other)
    {
        if(isequiped == true)
        {
            return;
        }

        if (other.gameObject.name == "MagicPrepare_R")
        {
            if (controllerR.inputDevice.TryGetFeatureValue(CommonUsages.grip, out float gripTargetR))
            {
                if (gripTargetR > 0.9)
                {
                    Instantiate(gun, gun_init_pointR);
                    isequiped = true;
                }
            }
        }
    }
}
