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
    public int passive1Level = 1;  // 0이면 비활성화.
    public int passive2Level = 1;  // 0이면 비활성화.
    public int passive3Level = 1;  // 0이면 비활성화.

    public bool use = false;


    public void DestroyAll(string destroy_except_name) //매개변수 from : mag inform
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
                    if (other.gameObject.name == "MagicPrepare_R")
                    {
                        if (triggerTargetL >= 0.9 && triggerTargetR >= 0.9)
                        {
                        if (use == false && GameObject.Find("TriggerPoint") != null) //triggerPoint는 차후 총없이 쓸수있는 마법나오면 전환
                        {
                            
                            use = true;
                            Debug.Log("Magic!");
                            tempMagic[0] = Instantiate(magic[0], magicPos_1);
                            //tempMagic1.GetComponent<MagicCubeManager>().magic = magic[0];
                            tempMagic[1] = Instantiate(magic[1], magicPos_2);
                            //tempMagic2.GetComponent<MagicCubeManager>().magic = magic[1];
                            tempMagic[2] = Instantiate(magic[2], magicPos_3);
                            //tempMagic3.GetComponent<MagicCubeManager>().magic = magic[2];

                        }
                        }
                    }
                }
            }
        
    }
}
