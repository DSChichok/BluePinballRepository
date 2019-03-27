using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DebugScript2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject Righter;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Righter.GetComponent<RightScript>().TeleportDown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Righter.GetComponent<RightScript>().TeleportUp();
    }
}