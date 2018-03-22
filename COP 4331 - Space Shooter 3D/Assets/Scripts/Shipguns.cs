using UnityEngine;

public class Shipguns : MonoBehaviour
{
	public float damage = 10f;
	public float speed = 100f;
	public float delayMax = 160f;
	public float delay = 0;
	public GameObject bullet;
	public GameObject bulletInst;

	public Camera bulletCam;
	public ParticleSystem muzzleFlash;
	public AudioSource bulletSound;

	void Update ()
	{

		if(delay>0)
			delay--;
	}

	public void Shoot()
	{
		if (delay <= 0)
		{
			bulletSound.Play();
			muzzleFlash.Play();
			bulletInst = Instantiate(bullet,transform.position,transform.rotation);
			Physics.IgnoreCollision(bulletInst.GetComponent<Collider>(),GetComponent<Collider>());
			bulletInst.GetComponent<Bullet>().damage = damage;
			bulletInst.GetComponent<Bullet>().speed = speed;
			bulletInst.transform.rotation = transform.rotation;
			
			bulletInst.GetComponent<Bullet>().player= gameObject;
			delay = delayMax;

			// Added tag to the bullet
			bulletInst.gameObject.tag = "Bullet";
		}
	}
}
