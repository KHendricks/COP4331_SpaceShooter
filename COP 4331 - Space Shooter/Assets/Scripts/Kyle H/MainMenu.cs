using GooglePlayGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
	private void Awake()
	{
		// Google Play Service
		PlayGamesPlatform.Activate();
		OnConnectionResponse(PlayGamesPlatform.Instance.localUser.authenticated);
	}

	private void OnConnectionResponse(bool status)
	{
		if (status)
		{
			GameObject disconnectedIcons = GameObject.Find("Disconnected");
			GameObject connectedIcons = GameObject.Find("Connected");
			disconnectedIcons.SetActive(false);
			connectedIcons.SetActive(true);
		}
		else
		{
			GameObject connectedIcons = GameObject.Find("Connected");
			GameObject disconnectedIcons = GameObject.Find("Disconnected");
			disconnectedIcons.SetActive(true);
			connectedIcons.SetActive(false);
		}
	}

	// On button click ask for login
	public void OnConnectClick()
	{
		Social.localUser.Authenticate((bool status) =>
		{
			OnConnectionResponse(status);
		});
	}

	public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void QuitGame()
	{
		Debug.Log("QUIT");
		Application.Quit();
	}
}
