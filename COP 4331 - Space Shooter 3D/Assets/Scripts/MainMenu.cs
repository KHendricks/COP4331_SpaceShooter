using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class MainMenu : MonoBehaviour
{
	public GameObject connectedMenu, disconnectedMenu;

	void Start()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		PlayGamesPlatform.Activate();
		CheckConnectionResponse(PlayGamesPlatform.Instance.localUser.authenticated);
	}

	public void PlayGame()
	{
		GameController.instance.ChangeHealth(100);
		SceneManager.LoadScene("Level1");
	}

	// function to check connection for play services
	private void CheckConnectionResponse(bool status)
	{
		// User is connected
		if (status)
		{
			Debug.Log("User is signed in");
			disconnectedMenu.SetActive(false);
			connectedMenu.SetActive(true);
		}
		else
		{
			Debug.Log("Not signed in");
			disconnectedMenu.SetActive(true);
			connectedMenu.SetActive(false);
		}
	}

	public void OnLoginClick()
	{
		PlayGamesPlatform.Instance.localUser.Authenticate((bool status) =>
		{
			CheckConnectionResponse(status);
		});
	}

	public void OnMultiplayerClick()
	{
		SceneManager.LoadScene("MultiplayerLevel");

	}

	public void SignOut()
	{
		PlayGamesPlatform.Instance.SignOut();
		CheckConnectionResponse(false);
	}

	public bool IsAuthenticated()
	{
		return PlayGamesPlatform.Instance.localUser.authenticated;
	}

	public void OnLeaderboardClick()
	{
		if (Social.localUser.authenticated)
		{
			Social.ShowLeaderboardUI();
		}
	}
}
