using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour 
{
	void OnCollisonEnter(Collision collision)
	{
		if (collision.gameObject.name == "Player")
		{
			GameController.instance.NextLevel(GameController.instance.upgradeSceneName);
		}
	}
}