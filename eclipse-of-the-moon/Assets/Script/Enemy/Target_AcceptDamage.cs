using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_AcceptDamage : MonoBehaviour
{
    public float particleTime;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Skill")
        {
            ParticleSystem particle = GetComponent<ParticleSystem>();
            particle.Play();
            MeshRenderer mr =GetComponent<MeshRenderer>();
            mr.enabled = false;
            Destroy(this.gameObject, particleTime);
        }
    }
}
