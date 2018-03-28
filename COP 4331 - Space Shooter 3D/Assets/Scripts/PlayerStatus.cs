using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;

// This script will handle player damage taken and upload of the score to the leaderboard

public class PlayerStatus : MonoBehaviour
{
	public float health;
	public AudioSource HitSound;

	private void Start()
	{
		health = GameController.instance.GetHealth();
	}

	private void Update()
	{
		health = GameController.instance.GetHealth();
		Death();
	}

	// Bug where death sound terminates early on death
	public void Death()
	{
		if (health <= 0)
		{			
            GameController.instance.isPlayerDead = true;
			PlayerPrefs.SetInt("Player Health", 0);
			PlayerPrefs.SetInt("Player Score", (int)GameController.instance.GetScore());
			SceneManager.LoadScene("EndOfGame");
		}
	}

	private void OnCollisionEnter(Collision col)
	{
		// When the player is hit by a generic bullet
		if (col.gameObject.tag.Equals("EnemyBullet"))
		{
			GameController.instance.ChangeHealth(-(int)col.gameObject.GetComponent<EnemyBullet>().damage);
			HitSound.Play();
			Destroy(col.gameObject);
		}
		if (col.gameObject.tag.Equals("Enemy"))
		{
			GameController.instance.ChangeHealth(-(int)col.gameObject.GetComponent<Enemy>().damage);
			HitSound.Play();
			Destroy(col.gameObject);
		}
	}
}
