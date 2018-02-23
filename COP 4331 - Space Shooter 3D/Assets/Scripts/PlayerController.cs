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
	public GameObject endGoal;
	public MovementNub movementNub;
	public MovementNub shootRotateNub;
	public GameObject playerShip;
	private float posy;
	private UnityEngine.AI.NavMeshAgent agent;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		posy = transform.position.y;
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		
        agent.destination = endGoal.transform.position;
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
		if (shootRotateNub.inputVector != Vector3.zero)
		{
			playerShip.GetComponent<Shipguns>().Shoot();
			rotHorizontal = shootRotateNub.inputVector.x;
			rotVertical = shootRotateNub.inputVector.z;
		}
		if(GetComponent<Collider>().bounds.Contains(playerShip.transform.position + new Vector3(moveHorizontal,moveVertical,0)))
		{
			playerShip.transform.position = playerShip.transform.position + new Vector3(moveHorizontal,moveVertical,0);
		}
		playerShip.transform.rotation = Quaternion.Slerp(playerShip.transform.rotation,Quaternion.Euler(transform.eulerAngles.x + -rotVertical*5,transform.eulerAngles.y + rotHorizontal*5,0),0.8f);
        
		
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
