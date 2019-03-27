using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip AudioClip_Bling;

    void Start()
    {
        Audio.loop = false;
        Audio.clip = AudioClip_Bling;
    }

    // Update is called once per frame
    void Update ()
    {
        if (transform.position.y < -9f)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Audio.Play();
    }
}