using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flatwoods : ShootingEnemy
{
	public bool active;
	private Quaternion rotation;
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		Startup();
		DoubleShooter();
		
	}
	private void DoubleShooter()
	{
		InvokeRepeating("DoubleShoot", 0, bulletDelay);
	}
	private void DoubleShoot()
	{
		if(GetComponent<Renderer>().isVisible)
		{
			bulletInst = Instantiate(bullet, transform.position+transform.right*5.5f+transform.up*12f, transform.rotation);
			Physics.IgnoreCollision(bulletInst.GetComponent<Collider>(), GetComponent<Collider>());
			bulletInst.GetComponent<EnemyBullet>().damage = bulletDamage;
			bulletInst.GetComponent<EnemyBullet>().speed = bulletSpeed;
			bulletInst.GetComponent<EnemyBullet>().shootType = EnemyBullet.ShotType.Regular;
			bulletInst.transform.rotation = transform.rotation;
			bulletInst.GetComponent<EnemyBullet>().player = player;

			// Added tag to the bullet
			bulletInst.gameObject.tag = "EnemyBullet";
			
			bulletInst = Instantiate(bullet, transform.position-transform.right*5.5f+transform.up*12f, transform.rotation);
			Physics.IgnoreCollision(bulletInst.GetComponent<Collider>(), GetComponent<Collider>());
			bulletInst.GetComponent<EnemyBullet>().damage = bulletDamage;
			bulletInst.GetComponent<EnemyBullet>().speed = bulletSpeed;
			bulletInst.GetComponent<EnemyBullet>().shootType = EnemyBullet.ShotType.Regular;
			bulletInst.transform.rotation = transform.rotation;
			bulletInst.GetComponent<EnemyBullet>().player = player;

			// Added tag to the bullet
			bulletInst.gameObject.tag = "EnemyBullet";
		}
	}
	public void Update()
	{
		Actions();
	}
}
