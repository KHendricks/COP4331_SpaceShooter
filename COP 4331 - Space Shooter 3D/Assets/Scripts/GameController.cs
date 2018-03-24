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
	private int maxHealth = 100;
    public bool damageAmpPurch = false;
    public bool isPlayerDead = false;
	public int levelIndex = 1;

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
        PlayerPrefs.SetInt("Damage Upgrade", 0);
	}
	
	
	void Start()
	{
		levelIndex = PlayerPrefs.GetInt("Player Level");
		playerHealth = PlayerPrefs.GetInt("Player Health");

		score = PlayerPrefs.GetInt("Player Score");

		if (PlayerPrefs.GetInt("Damage Upgrade") == 1)
			damageAmpPurch =  true;
		else
			damageAmpPurch = false;

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

	private void OnApplicationQuit()
	{
		if (!isPlayerDead)
		{
			PlayerPrefs.SetInt("Player Level", levelIndex);
			PlayerPrefs.SetInt("Player Health", playerHealth);
			PlayerPrefs.SetInt("Player Score", score);
			PlayerPrefs.SetInt("Damage Upgrade", damageAmpPurch ? 1 : 0);
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

	public int GetMaxHealth()
	{
		return maxHealth;
	}
}
