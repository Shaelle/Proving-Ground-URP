using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetPointer : MonoBehaviour
{

    [SerializeField] GameObject target;

    [SerializeField] ParticleSystem beam;

    private void OnEnable()
    {
        MouseTarget.OnCanHit += CanHit;
        MouseTarget.OnOutOfRange += OutOfReach;

        Hit.OnFireBeam += FireBeam;
    }

    private void OnDisable()
    {
        MouseTarget.OnCanHit -= CanHit;
        MouseTarget.OnOutOfRange -= OutOfReach;

        Hit.OnFireBeam -= FireBeam;
    }

    private void CanHit(Vector3 pos, float angle)
    {
       // target.SetActive(true);
    }

    private void OutOfReach()
    {
     //   target.SetActive(false);
    }


    void FireBeam(bool isFiring)
    {
        if (isFiring) beam.Play();
        else beam.Stop();
    }

}
