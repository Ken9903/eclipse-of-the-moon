using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class StatusUiController : MonoBehaviour
{
    public GameObject statusUi;
    bool isActiveUi = false;
    bool ready = true;

    public XRController right_Controller;


    void Update()
    {
        if (right_Controller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool buttonValue))
        {
            if(ready == true)
            {
                ready = false;
                if (buttonValue == true)
                {
                    if (isActiveUi == false)
                    {
                        statusUi.SetActive(true);
                        isActiveUi = true;
                    }
                    else
                    {
                        statusUi.SetActive(false);
                        isActiveUi = false;
                    }
                }
            }
            if(buttonValue == false)
            {
                ready = true;
            }
           
            
        }
    }
}
