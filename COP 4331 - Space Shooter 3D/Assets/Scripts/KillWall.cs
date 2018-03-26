using UnityEngine;

public class KillWall : MonoBehaviour
{
	void OnCollisionEnter (Collision col)
    {
		Debug.Log(col.gameObject.tag);
		if (col.gameObject.tag.Equals("EnemyBullet") ||col.gameObject.tag.Equals("Enemy") )
		{
			Destroy(col.gameObject);
		}
	}
}
