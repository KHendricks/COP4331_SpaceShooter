using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class MainMenu : MonoBehaviour
{
	public GameObject connectedMenu, disconnectedMenu;
	public GameObject ContinueBtn;

	void Start()
	{
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		PlayGamesPlatform.Activate();
		CheckConnectionResponse(PlayGamesPlatform.Instance.localUser.authenticated);

		if (PlayerPrefs.GetInt("Player Health") <= 0)
			ContinueBtn.SetActive(false);
		else
			ContinueBtn.SetActive(true);
	}

	public void NewGame()
	{
		// Deletes all PlayerPrefs but we should still preserve username before
		string username = PlayerPrefs.GetString("Username");
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetString("Username", username);

		PlayerPrefs.SetInt("Player Level", 1);
		// This should be set "maxhealth" from the game controller not a static value
		PlayerPrefs.SetInt("Player Health", 100);
		PlayerPrefs.SetInt("Player Score", 0);
		SceneManager.LoadScene("Level1");
	}

	public void ContinueGame()
	{
		if (PlayerPrefs.GetInt("Player Health") >= 0)
			SceneManager.LoadScene(PlayerPrefs.GetInt("Player Level"));
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
			PlayerPrefs.SetString("Username", PlayGamesPlatform.Instance.localUser.userName);
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
		SceneManager.LoadScene("Leaderboard");
	}
}
