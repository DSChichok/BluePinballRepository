using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LeftButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject LeftFlipper;
    public AudioSource Audio;
    public AudioClip AudioClip_Click;
    public bool FreeToClick;

    // Use this for initialization
    void Start ()
    {
        FreeToClick = false;
        Audio.loop = false;
        Audio.clip = AudioClip_Click;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!Application.isMobilePlatform)
        {
            if (Input.GetKey("left"))
            {
                LeftFlipper.GetComponent<LeftFlipperScript>().PressDown = true;
            }
            else
            {
                LeftFlipper.GetComponent<LeftFlipperScript>().PressDown = false;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("LeftDown");
        if (FreeToClick)
        {
            LeftFlipper.GetComponent<LeftFlipperScript>().PressDown = true;
            Audio.Play();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("LeftUp");
        LeftFlipper.GetComponent<LeftFlipperScript>().PressDown = false;
    }
}
