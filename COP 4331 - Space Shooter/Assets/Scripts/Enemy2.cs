using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy2 : MonoBehaviour 
{
	private int health = 3;
	private int bulletspeed = 200;
	public GameObject player;
	public GameObject enemyBullet;
	void Update () 
	{
		if(bulletspeed==0)
		{
			Quaternion temp =  Quaternion.AngleAxis(0f,Vector3.forward);
			Physics2D.IgnoreCollision(Instantiate(enemyBullet,transform.position,temp).GetComponent<Collider2D>(),GetComponent<Collider2D>());
			bulletspeed=200;
		}
		else
		{
			bulletspeed--;
		}
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
				player.GetComponent<playerController>().score+=150;
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
