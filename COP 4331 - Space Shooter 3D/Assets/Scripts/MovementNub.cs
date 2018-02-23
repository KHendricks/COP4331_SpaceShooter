using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MovementNub : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
	private Image joyStickImg, bgImg;
	public Vector3 inputVector;

	private void Start()
	{
		bgImg = GetComponent<Image>();
		joyStickImg = transform.GetChild(0).GetComponent<Image>();
		inputVector = Vector3.zero;
	}

	public virtual void OnDrag(PointerEventData ped)
	{
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
		{
			pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

			float x = (bgImg.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
			float y = (bgImg.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;

			inputVector = new Vector3(x, 0, y);
			inputVector = (inputVector.magnitude > 1) ? inputVector.normalized : inputVector;

			// Moves joyStickImg
			joyStickImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * (bgImg.rectTransform.sizeDelta.x / 3), inputVector.z * (bgImg.rectTransform.sizeDelta.y / 3), 0);
		}
	}

	public virtual void OnPointerDown(PointerEventData ped)
	{
		OnDrag(ped);
	}

	public virtual void OnPointerUp(PointerEventData ped)
	{
		inputVector = Vector3.zero;
		joyStickImg.rectTransform.anchoredPosition = Vector3.zero;
	}

}
