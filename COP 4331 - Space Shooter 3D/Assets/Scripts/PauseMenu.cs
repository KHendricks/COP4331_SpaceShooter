using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour 
{
	public GameObject pauseCanvas, notPausedCanvas;

	public void Start()
	{
		notPausedCanvas.SetActive(true);
		pauseCanvas.SetActive(false);
	}

	public void PauseGame()
	{
		Time.timeScale = 0f;
		pauseCanvas.SetActive(true);
		notPausedCanvas.SetActive(false);

	}

	public void ResumeGame()
	{
		Time.timeScale = 1f;
		pauseCanvas.SetActive(false);
		notPausedCanvas.SetActive(true);
	}
}
