using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTime : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,time);
    }


}
