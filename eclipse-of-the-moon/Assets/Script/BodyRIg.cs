using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRIg : MonoBehaviour
{
    public Transform xrHeadTrans;

    private Quaternion quaternion;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        position = xrHeadTrans.transform.position;
        position.y = xrHeadTrans.position.y - 0.5f;
        this.transform.position = position;

        quaternion = xrHeadTrans.transform.rotation;
        quaternion.x = 0;
        quaternion.z = 0;
        this.transform.rotation = quaternion;
    }
}
