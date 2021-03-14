using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootImpactSlider : MonoBehaviour
{
    public Material mat;
    public float cooldown, cooldownInv, factor, factorMin, time;
    public bool go;
    
    void Start()
    {
        mat.SetFloat("_ScaleGradient", 5);
        mat.SetFloat("_ScaleOpacity", 2);
        cooldownInv = 2f;
        cooldown = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            mat.SetFloat("_ScaleGradient", cooldown);
            mat.SetFloat("_ScaleOpacity", cooldownInv);
            cooldown -= factor;
            cooldownInv -= factorMin;
        }

        if (cooldown <= -3f)
        {
            Reset();
        }

        GetComponent<Renderer>().material = mat;
    }

    public void Reset()
    {
        go = false;
        mat.SetFloat("_ScaleGradient", 5);
        mat.SetFloat("_ScaleOpacity", 2);
        
        cooldownInv = 2f;
        cooldown = 5f;
    }
}
