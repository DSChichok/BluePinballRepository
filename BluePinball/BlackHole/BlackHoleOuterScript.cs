using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleOuterScript : MonoBehaviour
{
    public GameObject Black;
    public GameObject ScoreKeeper;
    public AudioSource Audio;
    public AudioClip AudioClip_ShieldHit;
    public AudioClip AudioClip_ShieldExplosion;
    public AudioClip AudioClip_LockedSound;
    public bool AlreadyPorted;

    int Hits;
    bool FollowHole;
    int BeingDamaged;
    int TotalHitsNeeded;
    float x;
    float y;

    // Use this for initialization
    void Start ()
    {
        AlreadyPorted = false;
        Audio.loop = false;
        Hits = 0;
        FollowHole = true;
        BeingDamaged = 0;
        TotalHitsNeeded = 9;
    }

    public void Reset()
    {
        FollowHole = true;
        Hits = 0;
        BeingDamaged = 0;
        AlreadyPorted = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (FollowHole)
        {
            if (BeingDamaged == 0)
            {
                transform.position = new Vector2(Black.transform.position.x, Black.transform.position.y);
            }
            else if(BeingDamaged > 0)
            {
                x = Random.Range(-.1f, .1f);
                y = Random.Range(-.1f, .1f);
                transform.position = new Vector2(Black.transform.position.x + x, Black.transform.position.y + y);
            }
        }
        else
        {
            if (!AlreadyPorted)
            {
                AlreadyPorted = true;
                Black.GetComponent<BlackHoleScript>().HoleReady = true;
                transform.position = new Vector2(10f, 10f);
            }
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Add to score
        ScoreKeeper.GetComponent<ScoreScript>().AddToScore(1);

        BeingDamaged++;
        Hits++;
        StartCoroutine(Shaking());

        if (Hits > TotalHitsNeeded)
        {
            FollowHole = false;
            Audio.clip = AudioClip_ShieldExplosion;
        }
        else
        {
            Audio.clip = AudioClip_ShieldHit;
        }
        Audio.Play();
    }

    IEnumerator Shaking()
    {
        yield return new WaitForSeconds(.2f);
        BeingDamaged--;
    }

    public void SuckedSound()
    {
        Audio.clip = AudioClip_LockedSound;
        Audio.Play();
    }
}
