using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroScript : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip AudioClip;

    // Use this for initialization
    void Start ()
    {
        Audio.loop = false;
        Audio.clip = AudioClip;
        StartCoroutine(StartDecay());
    }

    IEnumerator StartDecay()
    {
        //StartDecay
        yield return new WaitForSeconds(2f);

        //Destroy Rock
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Audio.Play();
    }
}