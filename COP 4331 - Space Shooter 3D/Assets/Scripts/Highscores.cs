using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Highscores : MonoBehaviour 
{
	public string privateCode = "5lnJ4H-7Pk6hllGYe8ORFw-WKkcrbEZ0G45riXR91Wnw";
	public string publicCode = "5ab5b3bc012b2e1068b3b0ea";
	public string webURL = "http://dreamlo.com/lb/";

	public Highscore[] highscoreList;
	static Highscores instance;
	DisplayHighscores highscoreDisplay;

	string username;
	int score;

	void Awake()
	{
		instance = this;
		highscoreDisplay = GetComponent<DisplayHighscores>();
	}

	public static void AddNewHighscore(string username, int score)
	{
		instance.StartCoroutine(instance.UploadNewScore(username, score));
		Debug.Log("Added new score");
	}

	IEnumerator UploadNewScore(string username, int score)
	{
		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty(www.error))
		{
			DownloadScores();
			Debug.Log("Score Upload Successful");
		}
	}

	public void DownloadScores()
	{
		StartCoroutine("DownloadTopScores");
	}

	IEnumerator DownloadTopScores()
	{
		WWW www = new WWW(webURL + publicCode + "/pipe/0/10");
		yield return www;

		if (string.IsNullOrEmpty(www.error))
			FormatHighScores(www.text);
		highscoreDisplay.OnHighscoresDownload(highscoreList);
	}

	private void FormatHighScores(string textStream)
	{
		string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
		highscoreList = new Highscore[entries.Length];

		for (int i = 0; i < entries.Length; i++)
		{
			string[] entryInfo = entries[i].Split(new char[] { '|' });
			highscoreList[i] = new Highscore(entryInfo[0], int.Parse(entryInfo[1]));
			Debug.Log(highscoreList[i].username + " : " + highscoreList[i].score);
		}
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}

public struct Highscore
{
	public string username;
	public int score;

	public Highscore(string _username, int _score)
	{
		username = _username;
		score = _score;
	}
}