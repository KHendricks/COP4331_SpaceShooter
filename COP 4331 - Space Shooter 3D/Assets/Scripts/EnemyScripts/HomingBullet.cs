using UnityEngine;

public class HomingBullet : MonoBehaviour
{
	private GameObject userPlayer;
	private Transform myTransform;
	public Transform target;
	public int speed;
	private Rigidbody rigidbody;
	void Start()
	{
		userPlayer = GameObject.FindGameObjectWithTag("Player");
		target = userPlayer.transform;
		transform.LookAt(target);
		rigidbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		transform.LookAt(target);
		rigidbody.AddForce(transform.forward*speed);
	}

}
