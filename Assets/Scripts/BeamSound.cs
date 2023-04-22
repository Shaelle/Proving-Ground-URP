using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamSound : MonoBehaviour
{

    [SerializeField] AudioClip sound;
    [SerializeField, Range(0, 1)] float volume = 0.7f;

    bool onCooldown = false;

    [SerializeField, Min(0)] float overlay = 0.7f;


    private void OnParticleTrigger()
    {
        if (!onCooldown)
        {
            AudioFX.instance.Play(sound, volume);

            onCooldown = true;
            StartCoroutine(Cooldown());
        }
    }


    IEnumerator Cooldown()
    {
  
        yield return new WaitForSeconds(sound.length * overlay);

        onCooldown = false;
    }


}
