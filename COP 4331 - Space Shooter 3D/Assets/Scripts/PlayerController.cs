using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public Rigidbody rb;

	// Update is called once per frame
	void FixedUpdate ()
 	{
		if (Input.GetKey("w"))
		{
			rb.AddForce(0, 0, 5000 * Time.deltaTime);
		}

		if (Input.GetKey("s"))
		{
			rb.AddForce(0, 0, -4000 * Time.deltaTime);
		}

		if (Input.GetKey("d"))
		{
			rb.AddForce(3500 * Time.deltaTime, 0, 0);
			rb.AddTorque (0, 0, -75 * Time.deltaTime);
		}

		if (Input.GetKey("a"))
		{
			rb.AddForce(-3500 * Time.deltaTime, 0, 0);
			rb.AddTorque (0, 0, 75 * Time.deltaTime);



		}
	}
}
