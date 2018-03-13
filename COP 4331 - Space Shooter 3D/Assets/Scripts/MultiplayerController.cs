// This script will handle the logging in of the user to their google play
// acount from the main menu and will allow the user to connect to the
// multiplayer service.

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MultiplayerController : Photon.MonoBehaviour
{
	public Text connectText;
	private bool connectedFlagText = false;
	public GameObject player;
	public GameObject lobbyCamera;
	public Transform spawnPoint;
	private GameObject waitingCanvas;
	private int playerCount = 0;
	private bool startedFlag = false;
	public GameObject connectionLostCanvas;

	private void Start()
	{
		PhotonNetwork.ConnectUsingSettings("0.1");
		waitingCanvas = GameObject.Find("WaitingScreen");
		WaitingScreen();
		connectionLostCanvas.SetActive(false);
		waitingCanvas.SetActive(false);
	}

	private void Update()
	{
		connectText.text = PhotonNetwork.connectionStateDetailed.ToString();
		playerCount = PhotonNetwork.playerList.Length;

		if (playerCount > 1)
		{
			startedFlag = true;
			PlayGame();
		}

		if (playerCount < 2 && startedFlag)
		{
			ConnectionLost();
		}
	}

	public virtual void OnJoinedLobby()
	{
		Debug.Log("We have joined the Lobby!");

		// Join room if it exists or create one
		PhotonNetwork.JoinOrCreateRoom("New", null, null);
	}

	// Can spawn the player here
	public virtual void OnJoinedRoom()
	{
		PhotonNetwork.Instantiate(player.name, spawnPoint.position, spawnPoint.rotation, 0);
		lobbyCamera.SetActive(false);
		waitingCanvas.SetActive(true);
		connectText.text = "Connected";

	}

	public void PlayGame()
	{
		waitingCanvas.SetActive(false);
		Time.timeScale = 1;
		connectText.text = "";
	}

	// Screen will be toggled on and game will be considered paused
	public void WaitingScreen()
	{
		waitingCanvas.SetActive(true);
		Time.timeScale = 0;
	}

	public void ConnectionLost()
	{
		connectionLostCanvas.SetActive(true);
	}

	public void ReturnToMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	// Syncs players movements
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			// We own this player: send the others our data
			stream.SendNext(transform.position); //position of the character
			stream.SendNext(transform.rotation); //rotation of the character

		}
		else
		{
			// Network player, receive data
			Vector3 syncPosition = (Vector3)stream.ReceiveNext();
			Quaternion syncRotation = (Quaternion)stream.ReceiveNext();
		}
	}
}
