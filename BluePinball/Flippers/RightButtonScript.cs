using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RightButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject RightFlipper;
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
            if (Input.GetKey("right"))
            {
                RightFlipper.GetComponent<RightFlipperScript>().PressDown = true;
            }
            else
            {
                RightFlipper.GetComponent<RightFlipperScript>().PressDown = false;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("RightDown");
        if (FreeToClick)
        {
            RightFlipper.GetComponent<RightFlipperScript>().PressDown = true;
            Audio.Play();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("RightUp");
        RightFlipper.GetComponent<RightFlipperScript>().PressDown = false;
    }
}
