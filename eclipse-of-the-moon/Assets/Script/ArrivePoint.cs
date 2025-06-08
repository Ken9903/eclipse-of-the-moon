using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrivePoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<ParticleSystem>().Stop();
        }
    }
}
