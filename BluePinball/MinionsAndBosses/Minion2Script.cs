using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion2Script : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip AudioClip_Ow;
    public AudioClip AudioClip_Death;
    public AudioClip AudioClip_Teleport;
    public bool Follow = true;
    float x;
    float y;
    int HitsTilDeath = 3;
    int BeingDamaged = 0;
    bool FollowTarget = false;
    public GameObject TargetToFollow;
    Vector2 orignalPosition;
    bool StopTeleport = false;

    //0 is idle
    //1 is hurt
    public int AnimationPhase = 0;
    public Animator anim;

    public void SetStillMinion2()
    {
        Audio.loop = false;
        Follow = true;
        orignalPosition = transform.position;
        StartCoroutine(StartTeleporting());
    }


    // Update is called once per frame
    void Update()
    {
        if (BeingDamaged > 0)
        {
            AnimationPhase = 1;
        }
        else
        {
            AnimationPhase = 0;
        }
        anim.SetInteger("Phase", AnimationPhase);


            if (HitsTilDeath > 0)
            {
                orignalPosition = transform.position;
                if (BeingDamaged > 0)
                {
                    x = Random.Range(-.1f, .1f);
                    y = Random.Range(-.1f, .1f);
                    transform.position = new Vector2(orignalPosition.x + x, orignalPosition.y + y);
                }
            }
            else
            {
                StopTeleport = true;
                transform.position = new Vector2(10f, 10f); //Out of the way
            }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Add to score
        foreach (GameObject score in GameObject.FindGameObjectsWithTag("Score"))
        {
            score.GetComponent<ScoreScript>().AddToScore(10);
        }

        //Subtract hits
        HitsTilDeath--;

        //Determine damage or death
        if (HitsTilDeath > 0) //Damage
        {
            Audio.clip = AudioClip_Ow;
            Audio.Play();
        }
        else //Death
        {
            Audio.clip = AudioClip_Death;
            Audio.Play();
            StopTeleport = true;
            StartCoroutine(KillMinion());
        }

        BeingDamaged++;
        StartCoroutine(Shaking());
    }

    IEnumerator Shaking()
    {
        yield return new WaitForSeconds(.2f);
        BeingDamaged--;
    }

    IEnumerator KillMinion()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    IEnumerator StartTeleporting()
    {
        while (!StopTeleport)
        {
            yield return new WaitForSeconds(2f);
            if (Follow)
            {
                Audio.clip = AudioClip_Teleport;
                Audio.Play();
                transform.position = new Vector2(Random.Range(-2f, 2f), Random.Range(-3f, 3f));
            }
        }
    }
}
