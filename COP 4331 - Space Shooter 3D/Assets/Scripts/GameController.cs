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
    public bool bombPurch = false;
    public bool isPlayerDead = false;
	public int level = 1;

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
        PlayerPrefs.SetInt("Bomb Upgrade", 0);
	}
	
	
	void Start()
	{
		level = PlayerPrefs.GetInt("Player Level");
		playerHealth = PlayerPrefs.GetInt("Player Health");

		score = PlayerPrefs.GetInt("Player Score");

		if (PlayerPrefs.GetInt("Damage Upgrade") == 1)
			damageAmpPurch =  true;
		else
			damageAmpPurch = false;
        
        if (PlayerPrefs.GetInt("Bomb Upgrade") == 1)
            bombPurch = true;
        else
            bombPurch = false;

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
            bombPurch = false;
            isPlayerDead = false;
        }
    }

	private void OnApplicationQuit()
	{
		if (!isPlayerDead)
		{
			PlayerPrefs.SetInt("Player Level", level);
			PlayerPrefs.SetInt("Player Health", playerHealth);
			PlayerPrefs.SetInt("Player Score", score);
			PlayerPrefs.SetInt("Damage Upgrade", damageAmpPurch ? 1 : 0);
            PlayerPrefs.SetInt("Bomb Upgrade", bombPurch ? 1 : 0);
        }
	}

	// This will be used to store all the level names
	private void InitializeLevelNames()
    {
        levelNames.Add("Level1");
        levelNames.Add("Level2");
    }

    public void NextLevel()
    {
		if(level<levelNames.Count)
		{
			SceneManager.LoadScene(levelNames[level], LoadSceneMode.Single);
			level++;
		}
		else
		{
			//You Win Script stuff
		}
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
