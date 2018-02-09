using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour 
{
	public int score = 0;
	public Text scoretext;
	public GameObject bullet;
	// Use this for initialization
	private int bulletdelay=10;
	// Update is called once per frame
	void Start()
	{
		Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(),GetComponent<Collider2D>());
	}
	void Update () 
	{
		if (Input.GetKey("w"))
		{
			if(GetComponent<Rigidbody2D>().velocity.magnitude < 20f)
				GetComponent<Rigidbody2D>().AddForce(Vector3.up*32,ForceMode2D.Force);
		}
		if (Input.GetKey("a"))
		{
			if(GetComponent<Rigidbody2D>().velocity.magnitude < 20f)
				GetComponent<Rigidbody2D>().AddForce(Vector3.right*-32,ForceMode2D.Force);
		}
		if (Input.GetKey("s"))
		{
			if(GetComponent<Rigidbody2D>().velocity.magnitude < 20f)
				GetComponent<Rigidbody2D>().AddForce(Vector3.up*-32,ForceMode2D.Force);
		}
		if (Input.GetKey("d"))
		{
			if(GetComponent<Rigidbody2D>().velocity.magnitude < 20f)
				GetComponent<Rigidbody2D>().AddForce(Vector3.right*32,ForceMode2D.Force);
		}
		if (Input.GetKey("q"))
		{
			if((GetComponent<Rigidbody2D>().angularVelocity < 800f))
				GetComponent<Rigidbody2D>().AddTorque(800f);
		}
		if (Input.GetKey("e"))
		{
			if(GetComponent<Rigidbody2D>().angularVelocity > -800f)
				GetComponent<Rigidbody2D>().AddTorque(-800f);
		}
	
        
		
        scoretext.text = ""+score;
	}
	public void Shoot()
	{
		if(bulletdelay==0)
		{
			Physics2D.IgnoreCollision(Instantiate(bullet,transform.position,transform.rotation).GetComponent<Collider2D>(),GetComponent<Collider2D>());
			bulletdelay=10;
		}
		else
			bulletdelay--;
	}
}
