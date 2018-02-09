using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyBullet : MonoBehaviour 
{
	private GameObject player;
	
	void Start()
	{
		player = GameObject.Find("Ship");
	}
	
	void Update () 
	{
		Vector3 temp = (player.transform.position - transform.position);
		temp.Normalize();
		float angles = Mathf.Atan2(GetComponent<Rigidbody2D>().velocity.y, GetComponent<Rigidbody2D>().velocity.x);
		transform.rotation = Quaternion.Euler(0f, 0f, angles*Mathf.Rad2Deg-90); 
	
		GetComponent<Rigidbody2D>().AddForce(temp*2,ForceMode2D.Force);
		
		
	}
	
	void OnCollisionEnter2D (Collision2D col)
    {
		if(col.gameObject.name == "Ship")
		{
			SceneManager.LoadScene("Game", LoadSceneMode.Single);
		}
        else if(col.gameObject.name != "Missle(Clone)")
        {
			Destroy(gameObject);
        }
    }
}
