using UnityEngine;

public class Enemy1 : MonoBehaviour
{
	public float health = 30;

	public void TakeDamage(float damageTaken)
	{
		health -= damageTaken;

		if (health <= 0f)
		{
			Death();
		}
	}

	void Death()
	{
		Destroy(gameObject);
	}
}
