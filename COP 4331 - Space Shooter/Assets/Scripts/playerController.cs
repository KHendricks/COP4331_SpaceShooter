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
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 8.0f;
		
		/*
		if((GetComponent<Rigidbody2D>().angularVelocity < 80f && x>0)|| (x<0&& GetComponent<Rigidbody2D>().angularVelocity > -80f))
			GetComponent<Rigidbody2D>().AddTorque(x*4);
        
        if(GetComponent<Rigidbody2D>().velocity.magnitude < 200f)
			GetComponent<Rigidbody2D>().AddForce(transform.up*z*4,ForceMode2D.Impulse);
		*/
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
