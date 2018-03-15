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

	private void Start()
	{
		health = GameController.instance.GetHealth();
	}

	private void Update()
	{
		health = GameController.instance.GetHealth();
		Death();
	}

	public void Death()
	{
		if (health <= 0)
		{
			Debug.Log("DEAD");
			Destroy(gameObject);
			PostScore();
            GameController.instance.isPlayerDead = true;
			SceneManager.LoadScene("MainMenu");
		}
	}

	private void OnCollisionEnter(Collision col)
	{
		// When the player is hit by a generic bullet
		if (col.gameObject.tag.Equals("EnemyBullet"))
		{
			GameController.instance.ChangeHealth(-30);
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
