﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public int score = 0;
	public Rigidbody rb;
	public Text scoreText;

	// Update is called once per frame
	void FixedUpdate ()
 	{
		if (Input.GetKey("w"))
		{
			rb.AddForce(0, 0, 1000 * Time.deltaTime);
		}

		if (Input.GetKey("s"))
		{
			rb.AddForce(0, 0, -1000 * Time.deltaTime);
		}

		if (Input.GetKey("d"))
		{
			rb.AddForce(1000 * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey("a"))
		{
			rb.AddForce(-1000 * Time.deltaTime, 0, 0);
		}

		scoreText.text = "" + score;
	}

	public float getScore()
	{
		return score;
	}

	public void addToScore(int val)
	{
		score += val;
	}
}
