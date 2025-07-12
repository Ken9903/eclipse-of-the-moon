using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MagicPrepare : MonoBehaviour
{
    public XRController controllerL;
    public XRController controllerR;

    public Transform magicPos_1;
    public Transform magicPos_2;
    public Transform magicPos_3;

    public GameObject[] magicCube = new GameObject[3];
    public GameObject[] magic = new GameObject[3];
    public int[] magicLevel = new int[3];

    GameObject[] tempMagic = new GameObject[3];

    public GameObject[] passiveBullet= new GameObject[3];
    public int passive1Level = 1;
    public int passive2Level = 1;
    public int passive3Level = 1;

    public bool use = false;

    public void DestroyAll(string destroy_except_name)
    {
        foreach (GameObject item in tempMagic)
        {
            if(item.name != destroy_except_name)
            {
                Destroy(item);
            }    
        }

        use = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (controllerL.inputDevice.TryGetFeatureValue(CommonUsages.grip, out float triggerTargetL))
        {
            if (controllerR.inputDevice.TryGetFeatureValue(CommonUsages.grip, out float triggerTargetR))
            {
                if (other.gameObject.name != "MagicPrepare_R")
                {
                    return;
                }
                if (triggerTargetL < 0.9 || triggerTargetR < 0.9)
                {
                    return;
                }

                if (!use && GameObject.Find("TriggerPoint") != null) 
                {                           
                    use = true;
                    tempMagic[0] = Instantiate(magic[0], magicPos_1);
                    tempMagic[1] = Instantiate(magic[1], magicPos_2);
                    tempMagic[2] = Instantiate(magic[2], magicPos_3);
                }                             
            }
        }     
    }
}