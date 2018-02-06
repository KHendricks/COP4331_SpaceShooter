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
		
        transform.Rotate(0, 0,x);
		transform.Translate(0, z,0);
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
