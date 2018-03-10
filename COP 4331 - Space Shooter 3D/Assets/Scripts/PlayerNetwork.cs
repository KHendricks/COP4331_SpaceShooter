using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetwork : MonoBehaviour 
{
	[SerializeField] private GameObject playerCamera;
	[SerializeField] private MonoBehaviour[] playerControlScripts;
	[SerializeField] private GameObject playerUI;

	private PhotonView photonView;

	private void Start()
	{
		photonView = GetComponent<PhotonView>();
		Init();
	}

	private void Init()
	{
		if (photonView.isMine)
		{
			; // Do Nothing! 
		}
		// Handles functionality for non local characters
		else
		{
			playerCamera.SetActive(false);
			playerUI.SetActive(false);

			foreach (MonoBehaviour m in playerControlScripts)
			{
				m.enabled = false;
			}	
		}
	}
}
