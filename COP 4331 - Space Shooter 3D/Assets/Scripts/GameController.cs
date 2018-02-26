using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
	public static GameController instance;
	private List<string> levelNames = new List<string>(); // Store level names so we can access them all easily
	public string upgradeSceneName = "Upgrade Screen";
	public int score = 0;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}

		InitializeLevelNames();
	}

	public void AddToScore(int val)
	{
		score += val;
	}

	public float GetScore()
	{
		return score;
	}

	// This will be used to store all the level names
	private void InitializeLevelNames()
	{	
		levelNames.Add("Next Level Name");
	}

	public void NextLevel(string nextLevel)
	{
		SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
	}
}
