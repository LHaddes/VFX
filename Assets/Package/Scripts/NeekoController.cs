using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;

public class NeekoController : MonoBehaviour
{
    public GameObject eSpell, rSpell, rBeam, rStockage, rShield;
    public float cooldown;
    private bool _rPreparation, _up, _down, _beam;
    

    public Transform firePoint;
    
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(eSpell, firePoint.position, firePoint.rotation);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            rStockage = Instantiate(rSpell, new Vector3(transform.position.x, 0.3f, transform.position.z), transform.rotation);
            rStockage.transform.Find("COLLIDER").gameObject.SetActive(false);
            _rPreparation = true;
            _up = false;
            _beam = false;
            _down = false;
            rBeam.SetActive(false);
            rShield.SetActive(true);
        }

        if (_rPreparation)
        {
            
            cooldown += Time.deltaTime;
            if (cooldown >= 1.2f && !_up)
            {
                Up();
                _up = true;
            }

            if (cooldown >= 1.3f && !_beam)
            {
                rBeam.SetActive(true);
                _beam = true;
            }

            if (cooldown >= 1.8f && !_down)
            {
                Down();
                _down = true;
                
            }

            if (cooldown >= 2f)
            {
                rShield.SetActive(false);
                FindObjectOfType<RootImpactSlider>().go = true;
                rStockage.transform.Find("COLLIDER").gameObject.SetActive(true);
                cooldown = 0f;
                _rPreparation = false;
            }
        }
    }

    public void Up()
    {
        transform.DOMoveY(6.5f, .3f);
    }

    public void Down()
    {
        transform.DOMoveY(1.3f, .2f);
    }
}
