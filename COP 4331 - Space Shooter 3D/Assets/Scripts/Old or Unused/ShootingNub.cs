using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShootingNub : MonoBehaviour
{
    public GameObject player;
    private Vector3 start;
    private Vector3 touchStart;
    private Vector3 touchEnd;
	private Vector3 offset;
	private int touchIndex = -1;
	public Vector3 inputVector;

    void Update ()
    {
		Touch touch;

		for (int i=0;i<Input.touchCount;i++)
		{
			touch= Input.touches[i];

			if(touch.phase == TouchPhase.Began)
			{
				if(touch.position.x < Screen.width/2)
				{
					Vector3 temp = transform.position;
					temp.x=(Camera.main.ScreenToWorldPoint(touch.position).x);
					temp.y=(Camera.main.ScreenToWorldPoint(touch.position).y);
					transform.position = temp;
					touchStart = touch.position;
					touchIndex = touch.fingerId;
				}
			}
			if(touchIndex==touch.fingerId)
			{
				player.GetComponent<Shipguns>().Shoot();
				if(touch.phase == TouchPhase.Moved)
				{
					touchEnd=touch.position;
				}
				if(touch.phase == TouchPhase.Ended)
				{
					touchIndex=-1;
				}
				player.transform.rotation = Quaternion.FromToRotation(transform.up,touchEnd-touchStart);
			}
		}

    }
}
