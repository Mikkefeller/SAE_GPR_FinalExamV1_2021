using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float lifetimeDuration = 2f;

    private void Start()
    {
        var particleSys = GetComponent<ParticleSystem>();
        particleSys.Play();
        if (particleSys != null)
        {
            lifetimeDuration = particleSys.main.duration;
        }
        Destroy(gameObject, lifetimeDuration);
    }
}
   
