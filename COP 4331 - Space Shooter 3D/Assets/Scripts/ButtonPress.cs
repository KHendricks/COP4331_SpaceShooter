using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonPress : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
	public bool isPressed = false;

	public virtual void OnPointerDown(PointerEventData ped)
	{
		isPressed = true;
	}

	public virtual void OnPointerUp(PointerEventData ped)
	{
		isPressed = false;
	}

}
