using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class HandOutside : MonoBehaviour
{
    public Transform handPos;
    int layerMask;

    public XRRayInteractor interactor;
    // Start is called before the first frame update
    void Start()
    {
        layerMask = 1 << LayerMask.NameToLayer("NotPermitted");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Physics.Raycast(transform.position, handPos.position - transform.position, Vector3.Distance(this.transform.position, handPos.position), layerMask))
        {
            interactor.enabled = false;
        }
        else
        {
            interactor.enabled = true;
        }
    }
}
