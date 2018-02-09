using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class MainMenu : MonoBehaviour
{
	private GameObject connectedMenu, disconnectedMenu;

	void Awake ()
	{
		// Finds the menu icons for the play service to work with
		disconnectedMenu = GameObject.Find("Disconnected");
		connectedMenu = GameObject.Find("Connected");

		// Activate the google play api on startup
		PlayGamesPlatform.Activate();
		CheckConnectionResponse(PlayGamesPlatform.Instance.localUser.authenticated);
	}

	// function to check connection for play services
	private void CheckConnectionResponse(bool status)
	{
		// User is connected
		if (status)
		{
			disconnectedMenu.SetActive(false);
			connectedMenu.SetActive(true);
		}
		else
		{
			disconnectedMenu.SetActive(true);
			connectedMenu.SetActive(false);
		}
	}

	public void OnLoginClick()
	{
		Social.localUser.Authenticate((bool status) =>
		{
			CheckConnectionResponse(status);
		});
	}

	public void OnLogoutClick()
	{
		PlayGamesPlatform.Instance.SignOut();
		CheckConnectionResponse(false);
	}

	public void OnLeaderboardClick()
	{
		if (Social.localUser.authenticated)
		{
			Social.ShowLeaderboardUI();
		}
	}

	public void PlayGame()
	{
		SceneManager.LoadScene("Level1");
	}

}
