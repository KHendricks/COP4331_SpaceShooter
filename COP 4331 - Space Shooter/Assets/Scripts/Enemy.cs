using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour 
{
	private int health = 3;
	public GameObject player;
	void Update () 
	{
		transform.Rotate(0, 0,-0.2F);
		transform.Translate(0, 0.006F,0);
	}
	
	void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.name == "Bullet(Clone)")
        {
			if(health==0)
			{
				Destroy(col.gameObject);
				Destroy(gameObject);
				player.GetComponent<playerController>().score+=100;
				GameController.game.enemyNumber--;
			}
			else
			{
				health--;
				Destroy(col.gameObject);
			}
        }
        if(col.gameObject.name == "Ship")
        {
			SceneManager.LoadScene("Game", LoadSceneMode.Single);
		}
    }
}
