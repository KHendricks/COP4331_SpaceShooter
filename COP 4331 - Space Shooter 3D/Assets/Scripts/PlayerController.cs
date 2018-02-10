using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public int score = 0;
	public Rigidbody rb;
	public Text scoreText;
	public float tilt;
	public float speed;
	public MovementNub movementNub;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate ()
 	{
		PlayerMovement();
		scoreText.text = "" + score;
	}

	void PlayerMovement()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;

		rb.rotation = Quaternion.Euler(rb.velocity.z * (tilt / 5), 180, rb.velocity.x * -tilt);
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
