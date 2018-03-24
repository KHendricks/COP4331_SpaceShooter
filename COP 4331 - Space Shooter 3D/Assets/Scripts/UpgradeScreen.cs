using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradeScreen : MonoBehaviour 
{
	public Text scoreText;
    public Text healthText;

    public Button healthButton;
    public Text healthUpgradeText;
    public Text healthCostText;

    public Button damageAmpButton;
    public Text damageAmpCostText;

    public Button continueButton;

    private int healthCost = 100;
    private int healthAmount = 10;
    private int damageCost = 500;

	void Start()
	{
        if (GameController.instance.GetHealth() < 100)
        {
            ChangeColor(healthButton, Color.green);
        }
        else
        {
            ChangeColor(healthButton, Color.red);
        }

        if (!GameController.instance.damageAmpPurch)
        {
            ChangeColor(damageAmpButton, Color.green);
        }
        else
        {
            ChangeColor(damageAmpButton, Color.red);
        }

		scoreText.text = "SCORE\n" + GameController.instance.GetScore();
        healthText.text = "HEALTH: " + GameController.instance.GetHealth();
        healthUpgradeText.text = "+ " + healthAmount + " HEALTH";
        healthCostText.text = "COST: " + healthCost;
        damageAmpCostText.text = "COST: " + damageCost;

        healthButton.onClick.AddListener(delegate()
        {
            HealthUpgrade();
        });

        damageAmpButton.onClick.AddListener(delegate()
        {
            DamageUpgrade();
        });

        continueButton.onClick.AddListener(delegate()
        {
            SceneManager.LoadScene("Level1");
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

            if (GameController.instance.GetHealth() >= 100)
            {
                ChangeColor(healthButton, Color.red);
            }
        }
    }

    void DamageUpgrade()
    {
        if (!GameController.instance.damageAmpPurch && GameController.instance.GetScore() >= damageCost)
        {
            PlayerPrefs.SetInt("Damage Upgrade", 1);
            GameController.instance.damageAmpPurch = true;
            GameController.instance.AddToScore(-damageCost);
            scoreText.text = "SCORE\n" + GameController.instance.GetScore();

            ChangeColor(damageAmpButton, Color.red);
        }
    }

    void ChangeColor(Button button, Color color)
    {
        ColorBlock cb = button.colors;
        cb.normalColor = color;
        button.colors = cb;
    }
}
