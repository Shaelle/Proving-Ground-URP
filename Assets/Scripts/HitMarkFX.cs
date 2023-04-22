using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMarkFX : MonoBehaviour
{

    [SerializeField] AudioClip fire;
    [SerializeField, Range(0, 1)] float volume = 0.5f;


    bool onCooldown = false;

    [SerializeField, Min(0)] float overlay = 0.7f;


    public static HitMarkFX instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }


    public void Play()
    {

        if (!onCooldown)
        {
            AudioFX.instance.Play(fire, volume);

            onCooldown = true;
            StartCoroutine(Cooldown());
        }
    }


    IEnumerator Cooldown()
    {

        yield return new WaitForSeconds(fire.length * overlay);

        onCooldown = false;
    }
}
