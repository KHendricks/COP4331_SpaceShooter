using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public static bool isPaused = false;
 	public GameObject pauseUI;

	public void ResumeGame()
	{
		isPaused = false;
		pauseUI.SetActive(false);
		Time.timeScale = 1;
	}

	public void PauseGame()
	{
		isPaused = true;
		pauseUI.SetActive(true);
		Time.timeScale = 0;
	}
}
