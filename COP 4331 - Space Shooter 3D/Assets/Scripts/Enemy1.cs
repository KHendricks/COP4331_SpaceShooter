using UnityEngine;

public class Enemy1 : MonoBehaviour
{
	public float health = 30;
	public GameObject player;

	public void TakeDamage(float damageTaken)
	{
		health -= damageTaken;

		if (health <= 0f)
		{
			player.GetComponent<PlayerController>().addToScore(100);
			Death();
		}
	}

	void Death()
	{
		Destroy(gameObject);
	}
}
