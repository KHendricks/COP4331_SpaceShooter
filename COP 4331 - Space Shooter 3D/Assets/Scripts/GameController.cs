using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
	public static GameController instance;
	private List<string> levelNames = new List<string>(); // Store level names so we can access them all easily
	public string upgradeSceneName = "UpgradeScreen";
	private int score = 0;
    private int playerHealth = 100;
    public bool damageAmpPurch = false;
    public bool isPlayerDead = false;

	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
		
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}

		InitializeLevelNames();
	}

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelLoaded;
    }

    void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        if(isPlayerDead)
        {
            playerHealth = 100;
            score = 0;
            damageAmpPurch = false;
            isPlayerDead = false;
        }
    }

    // This will be used to store all the level names
    private void InitializeLevelNames()
    {
        levelNames.Add("Next Level Name");
    }

    public void NextLevel(string nextLevel)
    {
        SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
    }

    public void AddToScore(int val)
	{
		score += val;
	}

	public float GetScore()
	{
		return score;
	}

    public void ChangeHealth(int val)
    {
        playerHealth += val;
    }

    public int GetHealth()
    {
        return playerHealth;
    }
}
