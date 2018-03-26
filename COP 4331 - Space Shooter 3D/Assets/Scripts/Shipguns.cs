using UnityEngine;

public class Shipguns : MonoBehaviour
{
    public double damage = 0;
	public float speed = 100f;
	public float delayMax = 160f;
	public float delay = 0;
	public GameObject bullet;
	public GameObject bulletInst;
    public GameObject bomb;
    public GameObject bombInst;

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

    public void Bomb()
    {
        if (delay <= 0)
        {
            bombInst = Instantiate(bomb, transform.position, transform.rotation);
            Physics.IgnoreCollision(bombInst.GetComponent<Collider>(), GetComponent<Collider>());
            bombInst.GetComponent<Bomb>().speed = speed;
            bombInst.transform.rotation = transform.rotation;

            bombInst.GetComponent<Bomb>().player = gameObject;
            delay = delayMax;

            // Added tag to the bullet
            bulletInst.gameObject.tag = "Bullet";
        }
    }
}
