using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
	
	public float bulletDamage = 10f;
	public float bulletSpeed = 100f;
	public float bulletDelay = 1f;

	public GameObject bullet;
	private GameObject bulletInst;
	private GameObject player;
		
	public EnemyBullet.ShotType attack = EnemyBullet.ShotType.Regular;

	void Start()
	{
		Startup();
		ShootStartup();
	}
	
	private void ShootStartup()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		if (attack == EnemyBullet.ShotType.Regular)
			InvokeRepeating("NormalShoot", 0, bulletDelay);
		else if (attack == EnemyBullet.ShotType.Homing)
			InvokeRepeating("HomingShoot", 0, bulletDelay);		
		else if (attack == EnemyBullet.ShotType.Triple)
			InvokeRepeating("TripleShoot", 0, bulletDelay);
					
	}
	
	public void Update()
	{
		Actions();
	}
	
	private void NormalShoot()
	{

		if(GetComponent<Renderer>().isVisible)
		{
			bulletInst = Instantiate(bullet, transform.position, transform.rotation);
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

	private void HomingShoot()
	{
		if(GetComponent<Renderer>().isVisible)
		{
			bulletInst = Instantiate(bullet, transform.position, transform.rotation);
			Physics.IgnoreCollision(bulletInst.GetComponent<Collider>(), GetComponent<Collider>());
			bulletInst.GetComponent<EnemyBullet>().damage = bulletDamage;
			bulletInst.GetComponent<EnemyBullet>().speed = bulletSpeed;
			bulletInst.GetComponent<EnemyBullet>().shootType = EnemyBullet.ShotType.Homing;
			bulletInst.transform.rotation = transform.rotation;
			bulletInst.GetComponent<EnemyBullet>().player = player;
			// Added tag to the bullet
			bulletInst.gameObject.tag = "EnemyBullet";
		}
	}
	private void TripleShoot()
	{
		//-30
		bulletInst = Instantiate(bullet, transform.position, transform.rotation);
		bulletInst.transform.Rotate(0,0,-30);
		Physics.IgnoreCollision(bulletInst.GetComponent<Collider>(), GetComponent<Collider>());
		bulletInst.GetComponent<EnemyBullet>().damage = bulletDamage;
		bulletInst.GetComponent<EnemyBullet>().speed = bulletSpeed;
		bulletInst.GetComponent<EnemyBullet>().shootType = EnemyBullet.ShotType.Triple;
		bulletInst.transform.rotation = transform.rotation;
		bulletInst.GetComponent<EnemyBullet>().player = player;
		// Added tag to the bullet
		bulletInst.gameObject.tag = "EnemyBullet";
		//0
		bulletInst = Instantiate(bullet, transform.position, transform.rotation);
		Physics.IgnoreCollision(bulletInst.GetComponent<Collider>(), GetComponent<Collider>());
		bulletInst.GetComponent<EnemyBullet>().damage = bulletDamage;
		bulletInst.GetComponent<EnemyBullet>().speed = bulletSpeed;
		bulletInst.GetComponent<EnemyBullet>().shootType = EnemyBullet.ShotType.Triple;
		bulletInst.transform.rotation = transform.rotation;
		bulletInst.GetComponent<EnemyBullet>().player = player;
		// Added tag to the bullet
		bulletInst.gameObject.tag = "EnemyBullet";
		//+30
		bulletInst = Instantiate(bullet, transform.position, transform.rotation);
		bulletInst.transform.Rotate(0,0,30);
		Physics.IgnoreCollision(bulletInst.GetComponent<Collider>(), GetComponent<Collider>());
		bulletInst.GetComponent<EnemyBullet>().damage = bulletDamage;
		bulletInst.GetComponent<EnemyBullet>().speed = bulletSpeed;
		bulletInst.GetComponent<EnemyBullet>().shootType = EnemyBullet.ShotType.Triple;
		bulletInst.transform.rotation = transform.rotation;
		bulletInst.GetComponent<EnemyBullet>().player = player;
		// Added tag to the bullet
		bulletInst.gameObject.tag = "EnemyBullet";
	}
	

}
