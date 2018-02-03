using GooglePlayGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
	GameObject disconnectedIcons;
	GameObject connectedIcons;

	private void Awake()
	{
		disconnectedIcons = GameObject.Find("Disconnected");
		connectedIcons = GameObject.Find("Connected");

		// Google Play Service
		PlayGamesPlatform.Activate();
		OnConnectionResponse(PlayGamesPlatform.Instance.localUser.authenticated);
	}

	private void OnConnectionResponse(bool status)
	{
		if (status)
		{
			disconnectedIcons.SetActive(false);
			connectedIcons.SetActive(true);
		}
		else
		{
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
