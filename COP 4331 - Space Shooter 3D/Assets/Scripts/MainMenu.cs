using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class MainMenu : MonoBehaviour
{
	public GUISkin guiSkin;

	private bool showLobbyDialogue;
	private string lobbyMessage;

	public void PlayGame()
	{
		SceneManager.LoadScene("Level1");
	}

	public void SetLobbyStatusMessage(string message)
	{
		lobbyMessage = message;
	}

	public void HideLobby()
	{
		lobbyMessage = "";
		showLobbyDialogue = false;
	}

	void OnGUI()
	{
		Debug.Log("Loading multiplayer game here!");

	}
}
