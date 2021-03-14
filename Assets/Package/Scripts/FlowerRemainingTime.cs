using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerRemainingTime : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystem.Stop();

        var main = _particleSystem.main;
        main.startLifetime = GetComponentInParent<NeekoESpell>().spellDuration;
        
        _particleSystem.Play();
    }

}
