using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHitScript : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip AudioClip_Wallhit;

    // Use this for initialization
    void Start ()
    {
        Audio.loop = false;
        Audio.clip = AudioClip_Wallhit;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Audio.Play();
    }
}