using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticle : MonoBehaviour
{
    public ParticleSystem particle;

    public void playParticle()
    {
        if(particle.isPlaying)
        {
            particle.Stop();
        }
        if(!particle.isPlaying)
        {
            particle.Play();
        }
        Debug.Log("particleplay");
    }
}
