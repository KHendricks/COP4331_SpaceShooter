using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerCage : Enemy
{
	
	private GameObject player;
	public GameObject cage;
	public float maxDist = 300;
	public float pounceSpeed = 1;
	public bool active;
	private Quaternion rotation;
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		Startup();
		
	}
	public void Update()
	{
		Death();
		if(active)
		{
			
			transform.position = transform.position + transform.forward*pounceSpeed;
			if(this.transform.position.y < player.transform.position.y-2f)
			{
				transform.position = transform.position + transform.up*.5f;
			}
		}
		else if(Vector3.Distance(this.transform.position,player.transform.position) <=maxDist)
		{
			active = true;
			cage.GetComponent<Animator>().SetBool("Open",true);
			GetComponent<Animator>().SetBool("Active",true);
			transform.LookAt(player.transform);
		}
	}
}
