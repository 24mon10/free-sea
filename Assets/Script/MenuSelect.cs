using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuSelect : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
	[SerializeField]
	Toggle toggle;

	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("OnPointerEnter");
		toggle.isOn = true;
	}

	public void OnSelect(BaseEventData eventData)
	{
		Debug.Log(this.gameObject.name + " was selected");
		toggle.isOn = true;
	}
}
