using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyBullet : MonoBehaviour 
{
	public GameObject player;
	
	void Update () 
	{
		Vector3 temp;
		transform.Translate(0, -0.05F,0);
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
