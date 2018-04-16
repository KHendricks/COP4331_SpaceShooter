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

    public Button fireSpeedButton;
    public Text fireSpeedText;
    public Text fireSpeedCostText;

    public Button damageAmpButton;
    public Text damageAmpCostText;

    public Button bombButton;
    public Text bombCostText;

    public Button continueButton;

    private int healthCost = 100;
    private int healthAmount = 10;
    private int damageCost = 300;
    private int bombCost = 1000;
    private int fireSpeedCost = 500;

    void Start()
    {

        if (GameController.instance.GetHealth() <= (100 - healthAmount) && GameController.instance.GetScore() >= healthCost)
        {
            ChangeColor(healthButton, Color.green);
        }
        else
        {
            ChangeColor(healthButton, Color.red);
        }

        if (!GameController.instance.damageAmpPurch && GameController.instance.GetScore() >= damageCost)
        {
            ChangeColor(damageAmpButton, Color.green);
        }
        else
        {
            ChangeColor(damageAmpButton, Color.red);
        }

        if (!GameController.instance.fireSpeedPurch && GameController.instance.GetScore() >= fireSpeedCost)
        {
            ChangeColor(fireSpeedButton, Color.green);
        }
        else
        {
            ChangeColor(fireSpeedButton, Color.red);
        }

        if (!GameController.instance.bombPurch && GameController.instance.GetScore() >= bombCost)
        {
            ChangeColor(bombButton, Color.green);
        }
        else
        {
            ChangeColor(bombButton, Color.red);
        }

        scoreText.text = "SCORE\n" + GameController.instance.GetScore();
        healthText.text = "HEALTH: " + GameController.instance.GetHealth();
        healthUpgradeText.text = "+ " + healthAmount + " HEALTH";
        healthCostText.text = "COST: " + healthCost;
        fireSpeedCostText.text = "COST: " + fireSpeedCost;
        damageAmpCostText.text = "COST: " + damageCost;
        bombCostText.text = "COST: " + bombCost;

        healthButton.onClick.AddListener(delegate ()
        {
            HealthUpgrade();
        });

        damageAmpButton.onClick.AddListener(delegate ()
        {
            DamageUpgrade();
        });

        fireSpeedButton.onClick.AddListener(delegate ()
        {
            FireSpeedUpgrade();
        });

        bombButton.onClick.AddListener(delegate ()
        {
            BombUpgrade();
        });
        continueButton.onClick.AddListener(delegate ()
        {
            GameController.instance.NextLevel();
        });
    }

    void Update()
    {
        if (GameController.instance.GetScore() < healthCost || GameController.instance.GetHealth() > (100 - healthAmount))
            ChangeColor(healthButton, Color.red);
        if (GameController.instance.GetScore() < damageCost)
            ChangeColor(damageAmpButton, Color.red);
        if (GameController.instance.GetScore() < fireSpeedCost)
            ChangeColor(fireSpeedButton, Color.red);
        if (GameController.instance.GetScore() < bombCost)
            ChangeColor(bombButton, Color.red);
    }

    void HealthUpgrade()
    {
        if (GameController.instance.GetHealth() <= (100 - healthAmount) && GameController.instance.GetScore() >= healthCost)
        {
            GameController.instance.ChangeHealth(10);
            GameController.instance.AddToScore(-healthCost);
            healthText.text = "HEALTH: " + GameController.instance.GetHealth();
            scoreText.text = "SCORE\n" + GameController.instance.GetScore();

            if (GameController.instance.GetHealth() >= 100 || GameController.instance.GetScore() < healthCost)
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

    void FireSpeedUpgrade()
    {
        if (!GameController.instance.fireSpeedPurch && GameController.instance.GetScore() >= fireSpeedCost)
        {
            PlayerPrefs.SetInt("Fire Speed Upgrade", 1);
            GameController.instance.fireSpeedPurch = true;
            GameController.instance.AddToScore(-fireSpeedCost);
            scoreText.text = "SCORE\n" + GameController.instance.GetScore();
            ChangeColor(fireSpeedButton, Color.red);
        }
    }

    void BombUpgrade()
    {
        if (!GameController.instance.bombPurch && GameController.instance.GetScore() >= bombCost)
        {
            PlayerPrefs.SetInt("Bomb Upgrade", 1);
            GameController.instance.bombPurch = true;
            GameController.instance.AddToScore(-bombCost);
            scoreText.text = "SCORE\n" + GameController.instance.GetScore();
            ChangeColor(bombButton, Color.red);
        }
    }

    void ChangeColor(Button button, Color color)
    {
        ColorBlock cb = button.colors;
        cb.normalColor = color;
        button.colors = cb;
    }
}
