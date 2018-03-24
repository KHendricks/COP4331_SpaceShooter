using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayHighscores : MonoBehaviour 
{
	public Text[] highscoreText;
	Highscores highscoreManager;
	public bool isLeaderboard;

	void Awake()
	{
		if (isLeaderboard)
			gameObject.SetActive(true);
		else
			gameObject.SetActive(false);
	 }

	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i < highscoreText.Length; i++)
		{
			highscoreText[i].text = i + 1 + ". Fetching...";
		}

		highscoreManager = GetComponent<Highscores>();
		StartCoroutine("RefreshHighscores");

//		int score = PlayerPrefs.GetInt("Player Score");
//		highscoreManager.AddNewHighscore("name", score);
	}

	public void OnHighscoresDownload(Highscore[] highscoreList)
	{
		for (int i = 0; i < highscoreText.Length; i++)
		{
			highscoreText[i].text = i + 1 + ". " ;
			if (highscoreList.Length > i)
			{
				highscoreText[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
			}
		}
	}

	IEnumerator RefreshHighscores()
	{
		while (true)
		{
			highscoreManager.DownloadScores();
			yield return new WaitForSeconds(30);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
