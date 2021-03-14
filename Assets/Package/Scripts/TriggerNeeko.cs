using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TriggerNeeko : MonoBehaviour
{
    public GameObject flower, rootEffect; 
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            /*ParticleSystem.MainModule main = flower.GetComponent<ParticleSystem>().main;
            main.duration = GetComponent<NeekoESpell>().spellDuration;
            main.startLifetime = GetComponent<NeekoESpell>().spellDuration;*/

            Instantiate(rootEffect, new Vector3(other.transform.position.x, other.transform.position.y - 1, other.transform.position.z), other.transform.rotation);
            flower.SetActive(true);
        }
    }
}
