using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour 
{
	public Slider slider;
	public Text healthAmt;
	private int maxHealth;
	private int health;

	private void Start()
	{
		maxHealth = 100;
	}

	// Update is called once per frame
	void Update () 
	{
		health = GameController.instance.GetHealth();

		// Fixes health bar display for when health goes into the negatives
		if (health <= 0)
			health = 0;

		slider.value = Mathf.Clamp01((float)(health) / (float)(maxHealth));
		healthAmt.text = health + " / " + maxHealth;
	}
}
