using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour 
{
	void Update () 
	{
		transform.Translate(0, 0.18F,0);
	}
	
	void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.name != "Bullet(Clone)"&& col.gameObject.name != "Ship")
        {
			Destroy(gameObject);
			GameController.game.enemyNumber--;
        }
    }
	
}
