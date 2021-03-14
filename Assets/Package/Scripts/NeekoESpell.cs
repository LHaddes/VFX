using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NeekoESpell : MonoBehaviour
{
	public float spellDuration, trailDuration;
    public float speed;
    public float fireRate;

	private float speedRandomness;
	private Vector3 offset;
	private bool collided, end;
	private Rigidbody rb;

	void Start () {	
		rb = GetComponent <Rigidbody> ();
	}

	void Update()
	{
		spellDuration -= Time.deltaTime;

		if (spellDuration <= 0 && !end)
		{
			EndParticles();
			end = true;
		}

		if (end)
		{
			trailDuration -= Time.deltaTime;
			if (trailDuration <= 0)
			{
				transform.GetChild(6).GetComponent<ParticleSystem>().Stop();
			}
		}
	}

	void FixedUpdate () {	
		if (speed != 0 && rb != null)
			rb.position += (transform.forward + offset)  * (speed * Time.deltaTime);
	}

	public void EndParticles()
	{
		List<Transform> tList = new List<Transform>();

		for (int i = 0; i < transform.childCount; i++)
		{
			tList.Add(transform.GetChild(i));
		}

		/*if (tList[5] != null)
		{
			tList[5].GetComponent<Renderer>().material.DOFade(0f, 1f);
			tList.RemoveAt(5);
		}*/
		
		tList.RemoveAt(tList.Count - 1);
		
		for (int i = 0; i < tList.Count; i++)
		{
			/*var main = tList[i].GetComponent<ParticleSystem>().main;
			main.startColor = new ParticleSystem.MinMaxGradient(new Color(0, 0, 0, 0));*/
			tList[i].GetComponent<ParticleSystem>().Stop();
		}

		if (!transform.GetChild(3).GetComponent<ParticleSystem>().IsAlive())
		{
			Destroy(gameObject);
		}
	}

}
