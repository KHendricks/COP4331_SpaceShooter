﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public int health;
	public int scoreOnDeath;
	public int bulletDamage;
	public GameObject enemy;

    public GameObject explosionEffect;

	private void Update()
	{
		Death();
	}

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag.Equals("Bullet"))
		{
			Debug.Log("HIT");
			health -= 10;
			Destroy(col.gameObject);
		}
	}

	public void Death()
	{
		if (health <= 0)
		{
            Instantiate(explosionEffect, transform.position, transform.rotation);
			Debug.Log("DEAD");
			Destroy(enemy);
			GameController.instance.AddToScore(scoreOnDeath);
		}
	}
}