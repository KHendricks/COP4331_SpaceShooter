using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndOfGameScript : MonoBehaviour 
{
	public Text score, usernameText;
	public GameObject postScoreBtn;

	// Use this for initialization
	void Start () 
	{
		score.text = PlayerPrefs.GetInt("Player Score").ToString();
		PostScore();
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void Leaderboard()
	{
		SceneManager.LoadScene("Leaderboard");
	}

	public void PostScore()
	{
		string username = PlayerPrefs.GetString("Username");
		int score = PlayerPrefs.GetInt("Player Score");
		Debug.Log(username + " : " + score);
		
		if (username != "")
			Highscores.AddNewHighscore(username, score);
		// SceneManager.LoadScene("Leaderboard");
	}
}
