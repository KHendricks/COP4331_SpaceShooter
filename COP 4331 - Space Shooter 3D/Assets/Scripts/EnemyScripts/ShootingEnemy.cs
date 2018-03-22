using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
	public enum ShotType {Regular,Homing};
	
	public float bulletDamage = 10f;
	public float bulletSpeed = 100f;
	public float bulletDelay = 1f;

	public GameObject bullet;
	private GameObject bulletInst;
	public ShotType attack = ShotType.Regular;

	void Start()
	{
		Startup();
		ShootStartup();
	}
	
	private void ShootStartup()
	{
		if (attack == ShotType.Regular)
			InvokeRepeating("NormalShoot", 0, bulletDelay);
		else if (attack == ShotType.Homing)
			InvokeRepeating("HomingShoot", 0, bulletDelay);		
	}
	
	public void Update()
	{
		Actions();
	}
	
	private void NormalShoot()
	{
		bulletInst = Instantiate(bullet, transform.position, transform.rotation);
		Physics.IgnoreCollision(bulletInst.GetComponent<Collider>(), GetComponent<Collider>());
		bulletInst.GetComponent<Bullet>().damage = bulletDamage;
		bulletInst.GetComponent<Bullet>().speed = bulletSpeed;
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
