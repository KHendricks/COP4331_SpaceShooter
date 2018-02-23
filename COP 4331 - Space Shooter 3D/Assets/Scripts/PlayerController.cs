using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public int score = 0;
	private Rigidbody rb;
	public Text scoreText;
	public float tilt;
	public float speed;
	public MovementNub movementNub;
	public MovementNub shootRotateNub;
	private float posy;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		posy = transform.position.y;
	}

	// Update is called once per frame
	void Update ()
 	{
		PlayerMovement();
		scoreText.text = "" + score;
	}

	void PlayerMovement()
	{
		// Keyboard Movement
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		float rotHorizontal = 0;
		float rotVertical = 0;
		Vector3 look = transform.position;

		// Joystick Movement
		if (movementNub.inputVector != Vector3.zero)
		{
			moveHorizontal = movementNub.inputVector.x;
			moveVertical = movementNub.inputVector.z;
		}
<<<<<<< HEAD

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;

		rb.rotation = Quaternion.Euler(rb.velocity.z * (tilt / 5), 180, rb.velocity.x * tilt);
=======
		if (shootRotateNub.inputVector != Vector3.zero)
		{
			GetComponent<Shipguns>().Shoot();
			rotHorizontal = shootRotateNub.inputVector.x;
			rotVertical = shootRotateNub.inputVector.z;
		}
		
		Vector3 movement = transform.rotation * new Vector3(moveHorizontal/2, 0.0f, moveVertical);
		
		
		transform.position = new Vector3(transform.position.x,posy,transform.position.z);
		rb.AddForce(movement*speed);
		transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(transform.eulerAngles.x + -rotVertical*5,transform.eulerAngles.y + rotHorizontal*5,0),0.8f);
		transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(rb.velocity.z * (tilt / 5), transform.eulerAngles.y, rb.velocity.x * -tilt),0.04f);
		
		
>>>>>>> test-candidate
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
