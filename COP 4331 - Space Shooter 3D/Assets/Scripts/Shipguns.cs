using UnityEngine;

public class Shipguns : MonoBehaviour
{
	public float damage = 10f;
	public float speed = 100f;
	public float delayMax = 16f;
	public float delay = 0;
	public GameObject bullet;
	public GameObject bulletInst;

	public Camera bulletCam;
	public ParticleSystem muzzleFlash;

	void Update ()
	{
		if (Input.GetKeyDown("space"))
		{
			Shoot();
		}
	}

	public void Shoot()
	{
		if(delay==0)
		{
			muzzleFlash.Play();
			bulletInst = Instantiate(bullet,transform.position,transform.rotation);
			Physics.IgnoreCollision(bulletInst.GetComponent<Collider>(),GetComponent<Collider>());
			bulletInst.GetComponent<Bullet>().damage = damage;
			bulletInst.GetComponent<Bullet>().speed = speed;
			bulletInst.transform.rotation = transform.rotation;
			
			bulletInst.GetComponent<Bullet>().player= gameObject;
			delay = delayMax;
		}
		else
		{
			delay--;
		}
	}
}
