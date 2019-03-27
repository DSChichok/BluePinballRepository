using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip AudioClip_Explosion;
    //public AnimationClip explode;
    //Animator m_Animator;

    // Use this for initialization
    void Start ()
    {
        Audio.loop = false;
        Audio.clip = AudioClip_Explosion;
        Audio.Play();

        StartCoroutine(PlayExplosion());
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Animation.set("Playing", FinishedPlaying);
    }

    IEnumerator PlayExplosion()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}