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

    public GameObject fireSpeedButton;
    public Text fireSpeedText;
    public int fireSpeedTimer = 30;
    public bool fireSpeedActivated;

    public GameObject damageAmpButton;
    public Text damageAmpText;
    public Text countdownText;
    public int damageTimer = 30;
    public bool damageAmpActivated;

    public GameObject bombButton;
    public Text bombText;

    void Start()
    {
        rb = playerShip.GetComponent<Rigidbody>();
        posy = transform.position.y;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        endGoal = GameObject.Find("EndPoint");
        Debug.Log(endGoal.transform.position);
        agent.destination = endGoal.transform.position;
        fireSpeedActivated = false;
        damageAmpActivated = false;

        if (GameController.instance.fireSpeedPurch || PlayerPrefs.GetInt("Fire Speed Upgrade") == 1)
        {
            fireSpeedButton.SetActive(true);
            fireSpeedText.text = "SPEED";

            fireSpeedButton.GetComponent<Button>().onClick.AddListener(delegate ()
            {
                if (!damageAmpActivated)
                    StartCoroutine(FireSpeed());
            });
        }
        else
        {
            fireSpeedButton.SetActive(false);
        }

        if (GameController.instance.damageAmpPurch || PlayerPrefs.GetInt("Damage Upgrade") == 1)
        {
            damageAmpButton.SetActive(true);
            damageAmpText.text = "DMG";

            damageAmpButton.GetComponent<Button>().onClick.AddListener(delegate ()
            {
                if (!fireSpeedActivated)
                    StartCoroutine(DamageAmp());
            });
        }
        else
        {
            damageAmpButton.SetActive(false);
        }

        if (GameController.instance.bombPurch || PlayerPrefs.GetInt("Bomb Upgrade") == 1)
        {
            bombButton.SetActive(true);
            bombText.text = "BOMB";

            bombButton.GetComponent<Button>().onClick.AddListener(delegate ()
            {
                Bomb();
            });
        }
        else
        {
            bombButton.SetActive(false);
        }


    }

    void Update()
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
        if (shootNub.isPressed)
        {

            playerShip.GetComponent<Shipguns>().Shoot();
        }

        rb.AddForce(transform.right * moveHorizontal * speed + transform.up * moveVertical * speed, ForceMode.Impulse);
        playerShip.transform.rotation = Quaternion.Slerp(playerShip.transform.rotation, Quaternion.Euler(transform.eulerAngles.x + -rotVertical * 5, transform.eulerAngles.y + rotHorizontal * 5, 0), 0.8f);
    }

    IEnumerator FireSpeed()
    {
        fireSpeedActivated = true;
        fireSpeedButton.SetActive(false);
        fireSpeedText.text = "";
        GameController.instance.fireSpeedPurch = false;
        PlayerPrefs.SetInt("Fire Speed Upgrade", 0);
        playerShip.GetComponent<Shipguns>().delayMax = playerShip.GetComponent<Shipguns>().delayMax / 2;

        int timer = fireSpeedTimer;
        bool flag = true;
        countdownText.text = ("DOUBLE FIRE SPEED");

        while (flag)
        {
            yield return new WaitForSecondsRealtime(1);
            countdownText.text = ("") + (--timer);

            if (timer < 0)
                flag = false;
        }

        countdownText.text = ("");
        Debug.Log("ended");

        playerShip.GetComponent<Shipguns>().delayMax = playerShip.GetComponent<Shipguns>().delayMax * 2;

        fireSpeedActivated = false;
    }

    // Increases damage by 50% for 1 minute
    IEnumerator DamageAmp()
    {
        damageAmpActivated = true;
        damageAmpButton.SetActive(false);
        damageAmpText.text = "";
        GameController.instance.damageAmpPurch = false;
        PlayerPrefs.SetInt("Damage Upgrade", 0);
        playerShip.GetComponent<Shipguns>().damage = playerShip.GetComponent<Shipguns>().damage * 2;

        int timer = damageTimer;
        bool flag = true;
        countdownText.text = ("DOUBLE DAMAGE");

        while (flag)
        {
            yield return new WaitForSecondsRealtime(1);
            countdownText.text = ("") + (--timer);

            if (timer < 0)
                flag = false;
        }

        countdownText.text = ("");
        Debug.Log("ended");

        playerShip.GetComponent<Shipguns>().damage = playerShip.GetComponent<Shipguns>().damage / 2;
        damageAmpActivated = false;
    }

    void Bomb()
    {
        bombButton.SetActive(false);
        bombText.text = "";
        GameController.instance.bombPurch = false;
        PlayerPrefs.SetInt("Bomb Upgrade", 0);

        playerShip.GetComponent<Shipguns>().Bomb();
    }
}
