using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot_Audio : MonoBehaviour
{
    public AudioClip bullet_wav;
    public AudioSource audio_source;
    // Start is called before the first frame update
    void Start()
    {
        audio_source = GetComponent<AudioSource>();
    }

    public void sound_shot()
    {
        audio_source.PlayOneShot(bullet_wav);
    }

}
