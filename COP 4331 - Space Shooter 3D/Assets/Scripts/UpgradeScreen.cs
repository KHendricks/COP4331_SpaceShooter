using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradeScreen : MonoBehaviour 
{
	public Text scoreText;
	public Button continueButton;

	void Start()
	{
		scoreText.text = "SCORE\n" + GameController.instance.score;
		continueButton.onClick.AddListener(delegate() {
											SceneManager.LoadScene("Level1"); 
											});
	}
}
