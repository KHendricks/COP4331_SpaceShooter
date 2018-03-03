using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi.Multiplayer;

public class MultiplayerController : MonoBehaviour, RealTimeMultiplayerListener
{
	public GameObject connectedMenu, disconnectedMenu;
	public MainMenu mainMenuScript;

	private uint minimumOpponents = 1;
	private uint maximumOpponents = 1;
	private uint gameVariation = 0;

	void Awake ()
	{
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

	private void ShowMPStatus(string message)
	{
		Debug.Log(message);
		if (mainMenuScript != null)
		{
			mainMenuScript.SetLobbyStatusMessage(message);
		}
	}

	public void OnRoomSetupProgress(float percent)
	{
		ShowMPStatus("We are " + percent + "% done with setup");
	}

	public void OnRoomConnected(bool success)
	{
		if (success)
		{
			ShowMPStatus("We are connected to the room! I would probably start our game now.");
		}
		else
		{
			ShowMPStatus("Uh-oh. Encountered some error connecting to the room.");
		}
	}

	public void OnLeftRoom()
	{
		ShowMPStatus("We have left the building!");
	}

	public void OnParticipantLeft(Participant participant)
	{

	}

	public void OnPeersConnected(string[] participantIds)
	{
		foreach (string participantID in participantIds)
		{
			ShowMPStatus("Player " + participantID + " has joined.");
		}
	}

	public void OnPeersDisconnected(string[] participantIds)
	{

	}

	public void OnRealTimeMessageReceived(bool isReliable, string senderId, byte[] data)
	{

	}
}
