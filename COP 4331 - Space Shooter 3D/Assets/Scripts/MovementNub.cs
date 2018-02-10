using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MovementNub : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image joyStickImg, bgImg;
    private Vector3 inputVector;

    private void Start()
    {
        bgImg = GetComponent<Image>();
        joyStickImg = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);
            inputVector = new Vector3(pos.x * 2 + 1, 0, pos.y * 2 - 1);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
            Debug.Log(inputVector);

            // Moves joyStickImg
            joyStickImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * (bgImg.rectTransform.sizeDelta.x / 3), inputVector.z * (bgImg.rectTransform.sizeDelta.y / 3));
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

    public float Horizontal()
    {
        return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        return Input.GetAxis("Vertical");
    }
}
