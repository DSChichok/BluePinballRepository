using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHitScript : MonoBehaviour
{
    GameObject ThatTarget;

    //Audio Clips
    public AudioSource Audio;
    public AudioClip Audioclip_RockHit;

    // Use this for initialization
    public void StartFollowing(GameObject ThisTarget)
    {
        Audio.loop = false;
        Audio.clip = Audioclip_RockHit;
        ThatTarget = ThisTarget;
        StartCoroutine(StartDecay());
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector2(ThatTarget.transform.position.x, ThatTarget.transform.position.y);
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Audio.Play();
    }

    IEnumerator StartDecay()
    {
        //StartDecay
        yield return new WaitForSeconds(2f);

        //Destroy Rock
        Destroy(gameObject);
    }
}