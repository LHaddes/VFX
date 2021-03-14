using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCone : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public float ratio;
    
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, transform.rotation.y - ratio, 0);
    }
}
