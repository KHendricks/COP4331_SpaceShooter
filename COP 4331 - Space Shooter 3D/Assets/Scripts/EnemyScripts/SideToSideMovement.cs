using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideToSideMovement : MonoBehaviour 
{
	public float speed;
	private float delta = 50f;
	private Vector3 startPos;

	// Use this for initialization
	void Start () 
	{
		startPos = transform.position;
	}

	// Update is called once per frame
	void Update () 
	{
		Vector3 updatePos = startPos;

		updatePos.x += delta * Mathf.Sin(Time.time * speed);

		transform.position = updatePos;
	}
}
