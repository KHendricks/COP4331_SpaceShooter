using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour 
{
	public int spinX = 0, spinY = 0, spinZ = 0;
	private float totalSpin = 0f;
	private int arc = 45;
	public bool LimitRotation = false;
	private float defaultRotation;

	private void Start()
	{
		defaultRotation = gameObject.transform.rotation.y;
	}

	// Update is called once per frame
	void Update () 
	{
		if (!LimitRotation)
		{
			totalSpin += spinY;

			if (totalSpin >= arc)
			{
				totalSpin = arc;
				spinY = -spinY;
			}

			if (totalSpin <= -arc)
			{
				totalSpin = -arc;
				spinY = -spinY;
			}
		}
		transform.Rotate(spinX, spinY, spinZ);
	}
}
