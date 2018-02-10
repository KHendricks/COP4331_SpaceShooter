using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	void OnCollisionEnemy(Collision other)
	{
		if (other.gameObject.GetComponent<StandardEnemy>())
		{
			Debug.Log("BOOM");
		}
	}
}
