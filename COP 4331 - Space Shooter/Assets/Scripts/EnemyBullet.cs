using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyBullet : MonoBehaviour 
{
	public GameObject player;
	

	
	void Update () 
	{
		//transform.Translate(0, 0.05F,0);
		GetComponent<Rigidbody2D>().AddForce((player.transform.position-transform.position).normalized*4f,ForceMode2D.Force);
		
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
