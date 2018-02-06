using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RightNub : MonoBehaviour 
{
    public GameObject player;
    private Vector3 start; 
    private Vector3 touchStart; 
    private Vector3 touchEnd; 
	private Vector3 offset;
	private int touchIndex = -1;
	
    void Start () 
    {
        start = transform.position;
        offset = transform.position - player.transform.position;
    }
   
    void Update () 
    {
		for (int i=0;i<Input.touchCount;i++) 
		{	
			Touch touch= Input.touches[i];
			
			if(GetComponent<Collider2D>().OverlapPoint(Camera.main.ScreenToWorldPoint(touch.position)) && touch.phase == TouchPhase.Began) 
			{
				touchStart = touch.position;
				touchIndex = touch.fingerId;	
			}
			if(touchIndex==touch.fingerId)
			{
				if(touch.phase == TouchPhase.Moved)
				{
					touchEnd=touch.position;				
				}
				if(touch.phase == TouchPhase.Ended)
				{
					touchIndex=-1;
				}
				player.transform.position = Vector3.MoveTowards(player.transform.position, player.transform.position+touchEnd - touchStart,0.1f);
			}
		}

		
    }
}
