using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Portal : MonoBehaviour 
{
	public Text winText;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			StartCoroutine(Win());
		}
	}

	IEnumerator Win()
    {
    	winText.text = "SUCCESS";
        yield return new WaitForSecondsRealtime(3);
        winText.text = "";

		// for multiplayer
		if (SceneManager.GetActiveScene().name == "Level1_Multiplayer")
		{
			SceneManager.LoadScene("EndOfGame");
		}
		else if (SceneManager.GetActiveScene().name == "Level2_Multiplayer")
		{
			SceneManager.LoadScene("EndOfGame");
		}
		else if (SceneManager.GetActiveScene().name == "Level3_Multiplayer")
		{
			SceneManager.LoadScene("EndOfGame");
		}
        else if(SceneManager.GetActiveScene().name == "Level3")
        {
            SceneManager.LoadScene("EndOfGame");
        }
		else
		{
			SceneManager.LoadScene("UpgradeScreen", LoadSceneMode.Single);
		}
    }
}