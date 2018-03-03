using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy1 : MonoBehaviour
{
	public float health = 30;

	private GameObject player;
	
	void Start()
	{
		player = GameObject.Find("Ship");
	}
	

	public void TakeDamage(float damageTaken)
	{
		health -= damageTaken;

		if (health <= 0f)
		{
			GameController.instance.AddToScore(100);
			Death();
		}
	}

	void Death()
	{
		Destroy(gameObject);
	}
	
	void OnCollisionEnter (Collision col)
    {
		Debug.Log(col.gameObject.name);
        if(col.gameObject.name == "Bullet(Clone)")
        {
			TakeDamage(col.gameObject.GetComponent<Bullet>().damage);
			Destroy(col.gameObject);
        }
        if(col.gameObject.name == "Ship")
        {
			SceneManager.LoadScene("Game", LoadSceneMode.Single);
		}
    }
}

	
