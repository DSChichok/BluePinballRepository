using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingerScript : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip AudioClip_Ping;

    // Use this for initialization
    void Start ()
    {
        Audio.loop = false;
        Audio.clip = AudioClip_Ping;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Audio.Play();
    }
}