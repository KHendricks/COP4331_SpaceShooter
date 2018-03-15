using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will have the enemy shoot straight ahead every few seconds

public class ShootAhead : MonoBehaviour
{
	// Same values for default player stats
	public float damage = 10f;
	public float speed = 100f;
	public float delay;

	public GameObject bullet;
	public GameObject bulletInst;
	public int shotType = 0;

	// Use this for initialization
	void Start()
	{
		// Call shoot every one second
		if (shotType == 0)
			InvokeRepeating("NormalShoot", 0, delay);
		else if (shotType == 1)
			InvokeRepeating("HomingShoot", 0, delay);

	}

	private void NormalShoot()
	{
		bulletInst = Instantiate(bullet, transform.position, transform.rotation);
		Physics.IgnoreCollision(bulletInst.GetComponent<Collider>(), GetComponent<Collider>());
		bulletInst.GetComponent<Bullet>().damage = damage;
		bulletInst.GetComponent<Bullet>().speed = speed;
		bulletInst.transform.rotation = transform.rotation;
		bulletInst.GetComponent<Bullet>().player = gameObject;

		// Added tag to the bullet
		bulletInst.gameObject.tag = "EnemyBullet";
	}

	private void HomingShoot()
	{
		bulletInst = Instantiate(bullet, transform.position, transform.rotation);

		// Added tag to the bullet
		bulletInst.gameObject.tag = "EnemyBullet";
	}
}
