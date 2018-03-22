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
			PostScore();
            GameController.instance.isPlayerDead = true;
			SceneManager.LoadScene("MainMenu");
			PlayerPrefs.SetInt("Player Health", 0);

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
	}

	private void PostScore()
	{
		float score = GameController.instance.GetScore();

		Social.ReportScore((int)score, "PlayerName", (bool success) => 
		{
			// handle success or failure
		});
	}
}
