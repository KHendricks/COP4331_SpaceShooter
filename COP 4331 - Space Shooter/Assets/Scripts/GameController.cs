using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static GameController game;
	private GameObject winText;
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

		winText = GameObject.Find("Mission Success");
	}

	void Start () 
	{
		enemyNumber = (GameObject.FindGameObjectsWithTag("Enemy")).Length;
	}
	
	void Update () 
	{
		if (enemyNumber <= 0)
		{
			winCondition();
		}	
	}

	void winCondition()
	{
		winText.gameObject.SetActive(true);
		new WaitForSeconds(10);
		winText.gameObject.SetActive(false);

		SceneManager.LoadScene("Upgrade");

		return;
	}
}
