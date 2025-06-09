using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class XR_Interact_GrapAndMove_Support : MonoBehaviour
{
    private XRController left_Controller;
    private XRRayInteractor left_Interactor;
    private XRInteractorLineVisual left_InteractorLineVisual;
    // Start is called before the first frame update
    void Start()
    {
        left_Controller = GetComponent<XRController>();
        left_Interactor = GetComponent<XRRayInteractor>();
        left_InteractorLineVisual = GetComponent<XRInteractorLineVisual>();

        
    }

    // Update is called once per frame
    void Update()
    {    
        if (left_Controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2D_TargetL))
        {     
            if (left_Controller.inputDevice.TryGetFeatureValue(Unity.XR.Oculus.OculusUsages.indexTouch, out bool indextouch))
            {
                if (primary2D_TargetL.y > 0.5f)
                {
                    left_Controller.selectUsage = InputHelpers.Button.PrimaryAxis2DUp;

                    left_Interactor.lineType = XRRayInteractor.LineType.ProjectileCurve;
                    left_Interactor.velocity = 8;

                    left_InteractorLineVisual.enabled = true;

                    left_Interactor.raycastMask = 1 << LayerMask.NameToLayer("Terrain") | 1 << LayerMask.NameToLayer("NotPermitted");


                }
                if (primary2D_TargetL.y == 0 && indextouch == true)
                {
                    left_Controller.selectUsage = InputHelpers.Button.Grip;

                    left_Interactor.lineType = XRRayInteractor.LineType.StraightLine;
                    left_Interactor.maxRaycastDistance = 1;

                    left_InteractorLineVisual.enabled = false;

                    left_Interactor.raycastMask = 1 << LayerMask.NameToLayer("GrabAble");
                }
                else if(primary2D_TargetL.y == 0 && indextouch == false )
                {
                    left_Interactor.lineType = XRRayInteractor.LineType.StraightLine;
                    left_Interactor.maxRaycastDistance = 10;

                    left_InteractorLineVisual.enabled = true;

                    left_Interactor.raycastMask = (1 << LayerMask.NameToLayer("UI")) |  (1 << LayerMask.NameToLayer("GrabAble"));
                }
            }
            
        }
        
    }
}
