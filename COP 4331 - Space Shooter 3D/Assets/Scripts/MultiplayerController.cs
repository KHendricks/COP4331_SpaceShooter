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
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject lobbyCamera;
	[SerializeField] private Transform spawnPoint;

	private void Start()
	{
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	private void Update()
	{
		connectText.text = PhotonNetwork.connectionStateDetailed.ToString();
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
	}
}
