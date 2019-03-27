using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DebugScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject Lefter;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        Lefter.GetComponent<LeftScript>().TeleportDown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Lefter.GetComponent<LeftScript>().TeleportUp();
    }
}