using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class PlayFeatures : MonoBehaviour
{
	private GameObject connectedMenu, disconnectedMenu;

	void OnApplicationQuit()
	{
		PlayGamesPlatform.Instance.SignOut();
	}

	void Awake ()
	{
		disconnectedMenu = GameObject.Find("Disconnected");
		connectedMenu = GameObject.Find("Connected");

		PlayGamesPlatform.Activate();
		PlayGamesPlatform.Instance.SignOut();
		CheckConnectionResponse(PlayGamesPlatform.Instance.localUser.authenticated);
	}

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
}
