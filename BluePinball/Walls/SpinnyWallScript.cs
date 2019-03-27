using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnyWallScript : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip AudioClip_Wallhit;

    // Use this for initialization
    void Start()
    {
        Audio.loop = false;
        Audio.clip = AudioClip_Wallhit;
    }

    // Update is called once per frame
    void Update ()
    {
        transform.Rotate(0, 0, 100 * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Audio.Play();
    }
}
