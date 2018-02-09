using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Ship")
		{
			SceneManager.LoadScene("Game");
		}
	}

}
