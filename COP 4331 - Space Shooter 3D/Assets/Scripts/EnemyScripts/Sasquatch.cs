using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sasquatch : Enemy
{
	
	private GameObject player;
	public float maxDist = 300;
	public float runSpeed = 3;
	public bool active;
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
			transform.position = transform.position + transform.forward*runSpeed;
		}
		else if(Vector3.Distance(this.transform.position,player.transform.position) <=maxDist)
		{
			active = true;
		}
	}
}
