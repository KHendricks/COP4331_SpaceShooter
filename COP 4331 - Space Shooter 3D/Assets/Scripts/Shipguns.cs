using UnityEngine;

public class Shipguns : MonoBehaviour
{
	public float damage = 10f;
	public float range = 100f;

	public Camera bulletCam;
	public ParticleSystem muzzleFlash;

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
	}

	void Shoot()
	{
		RaycastHit hit;
		muzzleFlash.Play();
		if (Physics.Raycast(bulletCam.transform.position, bulletCam.transform.forward, out hit))
		{
			Debug.Log(hit.transform.name);
			Enemy1 enemy = hit.transform.GetComponent<Enemy1>();
			if (enemy != null)
			{
				enemy.TakeDamage(damage);
			}
		}
	}
}
