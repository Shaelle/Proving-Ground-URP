using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ParticleSystem))]
public class Beam : MonoBehaviour
{

    ParticleSystem particles;

    List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();

    private void Awake()
    {
        particles = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ISparkTarget target = other.GetComponent<ISparkTarget>();

        if (target != null)
        {
            int num = particles.GetCollisionEvents(other, collisionEvents);

            for (int i = 0; i < num; i++)
            {
                target.Hit(collisionEvents[i].intersection);
            }

            
        }
    }
}
