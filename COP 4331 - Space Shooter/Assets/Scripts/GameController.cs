using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController game;
	public GameObject panel;
	public Text winText;
	public int enemyNumber = 0;

	void Awake()
	{
		if (game == null)
		{
			game = this;
		}
		else
		{
			Destroy(gameObject);
		}
		panel.SetActive(false);
	}

	void Start () 
	{
		enemyNumber = (GameObject.FindGameObjectsWithTag("Enemy")).Length;
	}
	
	void Update () 
	{
		Screen.orientation = ScreenOrientation.AutoRotation; // this just rotates the screen -Jerry
		if (enemyNumber <= 0)
		{
			winCondition();
		}	
	}

	void winCondition()
	{
		panel.SetActive(true);
		winText.text = "MISSION SUCCESS";
		new WaitForSeconds(10);
		panel.SetActive(false);
		winText.text = "";

		SceneManager.LoadScene("Upgrade");

		return;
	}
}
