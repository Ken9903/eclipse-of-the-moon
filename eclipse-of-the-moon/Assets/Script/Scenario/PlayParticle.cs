using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticle : MonoBehaviour
{
    public ParticleSystem particle;

    private void Start()
    {
        
    }
    public void playParticle()
    {
        if(particle.isPlaying == true)
        {
            particle.Stop();
        }
        if(
            particle.isPlaying == false)
        {
            particle.Play();
        }
        Debug.Log("particleplay");
    }
}
