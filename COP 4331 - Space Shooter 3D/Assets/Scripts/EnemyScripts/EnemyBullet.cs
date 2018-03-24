using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
	public double damage = 30f;
	public float deathTime = 16f;
	void Start()
	{
		Destroy(gameObject, deathTime);
	}
}
