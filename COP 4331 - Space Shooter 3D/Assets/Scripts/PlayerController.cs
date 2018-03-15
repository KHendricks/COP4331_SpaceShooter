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
	public MovementNub shootRotateNub;
	public GameObject playerShip;
	private float posy;
	private UnityEngine.AI.NavMeshAgent agent;

	public Image crosshair;
	public Camera mainCam;
	private Vector3 dir;
	private float sensitivity = 300;

    public Button damageAmpButton;
    private double damage = 10;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		posy = transform.position.y;
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		endGoal = GameObject.Find("EndPoint");
		Debug.Log(endGoal.transform.position);
        agent.destination = endGoal.transform.position;

        if (GameController.instance.damageAmpPurch)
        {
            damageAmpButton.enabled = true;

            damageAmpButton.onClick.AddListener(delegate ()
            {
                StartCoroutine(DamageAmp());
            });
        }
	}

	void LateUpdate ()
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

		// Joystick Movement
		if (movementNub.inputVector != Vector3.zero)
		{
			moveHorizontal = movementNub.inputVector.x;
			moveVertical = movementNub.inputVector.z;
		}
		// Shooting nub
		if (shootRotateNub.inputVector != Vector3.zero)
		{
			playerShip.GetComponent<Shipguns>().Shoot();
			rotHorizontal = shootRotateNub.inputVector.x;
			rotVertical = shootRotateNub.inputVector.z;

			// Move the corsshair where the player is shooting
			dir = mainCam.WorldToScreenPoint(playerShip.GetComponent<Shipguns>().bulletInst.GetComponent<Bullet>().shootDir.GetPoint(400));
			crosshair.transform.position = Vector3.MoveTowards(crosshair.transform.position, dir, sensitivity * Time.deltaTime);
		}

		if(GetComponent<Collider>().bounds.Contains(playerShip.transform.position + transform.right*moveHorizontal*speed*2))
		{
			playerShip.transform.position = playerShip.transform.position + transform.right*moveHorizontal*speed;
		}
		if(GetComponent<Collider>().bounds.Contains(playerShip.transform.position + transform.up*moveVertical*speed*2))
		{
			playerShip.transform.position = playerShip.transform.position + transform.up*moveVertical*speed;
		}
		playerShip.transform.rotation = Quaternion.Slerp(playerShip.transform.rotation,Quaternion.Euler(transform.eulerAngles.x + -rotVertical*5,transform.eulerAngles.y + rotHorizontal*5,0),0.8f);
	}

    // Increases damage by 1.5% for 1 minute
    IEnumerator DamageAmp()
    {
        damageAmpButton.enabled = false;
        GameController.instance.damageAmpPurch = false;
        damage = damage * 1.5;
        yield return new WaitForSecondsRealtime(60);
        Debug.Log("ended");
        damage = damage / 1.5;
    }
}
