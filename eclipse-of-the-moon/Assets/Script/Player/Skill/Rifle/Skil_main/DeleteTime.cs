using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTime : MonoBehaviour
{
    public float delete_time;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, delete_time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
