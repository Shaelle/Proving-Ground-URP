using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioFX : MonoBehaviour
{

    AudioSource source;

    public static AudioFX instance;

  
    private void Awake()
    {
        source = GetComponent<AudioSource>();

        if (instance == null) instance = this;
    }


    public void Play(AudioClip clip, float volume = 1)
    {
        source.PlayOneShot(clip, volume);
    }



}
