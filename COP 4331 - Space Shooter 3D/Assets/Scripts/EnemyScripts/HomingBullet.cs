using UnityEngine;

public class HomingBullet : MonoBehaviour
{
	public float deathTime = 4f;
	private GameObject userPlayer;
	private Transform myTransform;
	public Transform target;
	public int speed;

	private void Awake()
	{
		myTransform = transform;
	}

	void Start()
	{
		userPlayer = GameObject.FindGameObjectWithTag("Player");
		target = userPlayer.transform;
		myTransform.LookAt(target);

		Destroy(gameObject, deathTime);
	}

	void Update()
	{
		float distToMove = speed * Time.deltaTime;
		myTransform.Translate(Vector3.forward * distToMove);
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}
	}
}
