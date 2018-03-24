using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int health;
	public int scoreOnDeath;
	public double damage;
	public Vector3 speed = new Vector3(0,0,0);
	public Vector3 magnitude = new Vector3(0,0,0);
	public Vector3 rotationMagnitude = new Vector3(0,0,0);
	public Vector3 rotationSpeed = new Vector3(0,0,0);
	private Vector3 startPos;
	private Quaternion startRotation;
	

    public GameObject explosionEffect;
    public GameObject impactEffect;
	
	public void Start()
	{
		Startup();
	}
	
	public void Startup()
	{
		startPos = transform.position;
		startRotation = transform.rotation;		
	}
	
	public void Update()
	{
		Actions();
	}
	
	public void Actions()
	{
		//Movement
		transform.position= startPos +  
			transform.right * magnitude.z * Mathf.Sin(Time.time * speed.z)
			+ transform.up * magnitude.y * Mathf.Sin(Time.time * speed.y)
			+ transform.forward * magnitude.x * Mathf.Sin(Time.time * speed.x);
		//Rotation
		transform.rotation = startRotation;
		transform.Rotate(rotationMagnitude.x*Mathf.Sin(Time.time * rotationSpeed.x),rotationMagnitude.y*Mathf.Sin(Time.time * rotationSpeed.y),rotationMagnitude.z*Mathf.Sin(Time.time * rotationSpeed.z)); 
		
		
		Death();		
	}
	
	private void OnCollisionEnter(Collision col)
	{
		
		if (col.gameObject.tag.Equals("Bullet"))
		{
			double damage = 0;
			if(col.gameObject.GetComponent<Bullet>() != null)
				damage = col.gameObject.GetComponent<Bullet>().damage;
			if(damage > 0f)
				health = health - (int)damage;
			Destroy(col.gameObject);
            Instantiate(impactEffect, transform.position, transform.rotation);
		}
	}

	public void Death()
	{
		if (health <= 0)
		{
            Instantiate(explosionEffect, transform.position, transform.rotation);
			Destroy(gameObject);
			GameController.instance.AddToScore(scoreOnDeath);
		}
	}
}
