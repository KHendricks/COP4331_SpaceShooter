using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradeScreen : MonoBehaviour 
{
	public Text scoreText;
	public Button continueButton;
    public Text healthText;
    public Button healthButton;

    private int healthCost = 20;

	void Start()
	{
		scoreText.text = "SCORE\n" + GameController.instance.GetScore();
		continueButton.onClick.AddListener(delegate() 
        {
		    SceneManager.LoadScene("Level1"); 
		});

        healthText.text = "HEALTH: " + GameController.instance.GetHealth();
        healthButton.onClick.AddListener(delegate()
        {
            HealthUpgrade();
        });
	}

    void HealthUpgrade()
    {
        if (GameController.instance.GetHealth() < 100 && GameController.instance.GetScore() >= healthCost)
        {
            GameController.instance.ChangeHealth(10);
            GameController.instance.AddToScore(-healthCost);
            healthText.text = "HEALTH: " + GameController.instance.GetHealth();
            scoreText.text = "SCORE\n" + GameController.instance.GetScore();
        }
    }
}
