using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public static bool isPaused = false;
 	public GameObject pauseUI;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (isPaused)
			{
				ResumeGame();
			}
			else
			{
				PauseGame();
			}
		}
	}

	public void ResumeGame()
	{
		isPaused = false;
		pauseUI.SetActive(false);
		Time.timeScale = 1f;
	}

	public void PauseGame()
	{
		isPaused = true;
		pauseUI.SetActive(true);
		Time.timeScale = 0f;
	}
}
