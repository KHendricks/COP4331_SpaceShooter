using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	//public int score = 0;
	private Rigidbody rb;
	public Text scoreText;
	public float tilt;
	public float speed;
	private GameObject endGoal;
	public MovementNub movementNub;
	public ButtonPress shootNub;
	public GameObject playerShip;
	private float posy;
	private UnityEngine.AI.NavMeshAgent agent;

	public Image crosshair;
	public Camera mainCam;
	private Vector3 dir;
	private float sensitivity = 300;

    public Button damageAmpButton;
    public Text damageAmpText;
    private double damage = 10;

	void Start()
	{
		
		posy = transform.position.y;
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		endGoal = GameObject.Find("EndPoint");
		Debug.Log(endGoal.transform.position);
        agent.destination = endGoal.transform.position;

        if (GameController.instance.damageAmpPurch)
        {
            damageAmpButton.interactable = true;
            damageAmpText.text = "DMG";

            damageAmpButton.onClick.AddListener(delegate ()
            {
                StartCoroutine(DamageAmp());
            });
        }
        rb = playerShip.GetComponent<Rigidbody>();
	}

	void Update ()
 	{
		PlayerMovement();
		scoreText.text = "" + GameController.instance.GetScore();
	}

	void PlayerMovement()
	{
		// Keyboard Movement
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		float rotHorizontal = 0;
		float rotVertical = 0;
		Vector3 look = transform.position;
		Vector3 movement;
		// Joystick Movement
		if (movementNub.inputVector != Vector3.zero)
		{
			moveHorizontal = movementNub.inputVector.x;
			moveVertical = movementNub.inputVector.z;
		} 
		// Shooting nub
		if(shootNub.isPressed)
		{
			
			playerShip.GetComponent<Shipguns>().Shoot();
		}
		
		rb.AddForce(transform.right*moveHorizontal*speed + transform.up*moveVertical*speed,ForceMode.Impulse);
		playerShip.transform.rotation = Quaternion.Slerp(playerShip.transform.rotation,Quaternion.Euler(transform.eulerAngles.x + -rotVertical*5,transform.eulerAngles.y + rotHorizontal*5,0),0.8f);
	}

    // Increases damage by 1.5% for 1 minute
    IEnumerator DamageAmp()
    {
        damageAmpButton.interactable = false;
        damageAmpText.text = "";
        GameController.instance.damageAmpPurch = false;
        damage = damage * 1.5;
        yield return new WaitForSecondsRealtime(60);
        Debug.Log("ended");
        damage = damage / 1.5;
    }
}
