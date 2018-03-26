using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
	public float damage = 30f;
	public float speed = 1f;
	public GameObject player;
	public float deathTime = 16f;
	private Rigidbody rigidbody;
	public enum ShotType {Regular,Homing,Triple};
	public ShotType shootType;
	void Start()
	{
		Destroy(gameObject, deathTime);

		if(shootType == ShotType.Homing)
			transform.LookAt(player.transform);
		rigidbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if(shootType == ShotType.Homing)
			transform.LookAt(player.transform);
		rigidbody.AddForce(transform.forward*speed);
	}
}
