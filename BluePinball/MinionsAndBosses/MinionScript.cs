using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionScript : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip AudioClip_Ow;
    public AudioClip AudioClip_Death;
    public bool Follow = false;
    float x;
    float y;
    int HitsTilDeath = 3;
    int BeingDamaged = 0;
    bool FollowTarget = false;
    public GameObject TargetToFollow;
    Vector2 orignalPosition;

    //0 is idle
    //1 is hurt
    public int AnimationPhase = 0;
    public Animator anim;

    public void SetStillMinion()
    {
        Audio.loop = false;
        orignalPosition = transform.position;
    }

    public void FollowThisTarget(GameObject target)
    {
        TargetToFollow = target;
        Audio.loop = false;
        FollowTarget = true;
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

        if (FollowTarget) //Moving minion
        {
            if (HitsTilDeath > 0)
            {
                if (BeingDamaged == 0)
                {
                    transform.position = new Vector2(TargetToFollow.transform.position.x, TargetToFollow.transform.position.y);
                }
                else if (BeingDamaged > 0)
                {
                    x = Random.Range(-.1f, .1f);
                    y = Random.Range(-.1f, .1f);
                    transform.position = new Vector2(TargetToFollow.transform.position.x + x, TargetToFollow.transform.position.y + y);
                }
            }
            else
            {
                transform.position = new Vector2(10f, 10f); //Out of the way
            }
        }
        else  //Still minion
        {
            if (HitsTilDeath > 0)
            {
                if (BeingDamaged > 0)
                {
                    x = Random.Range(-.1f, .1f);
                    y = Random.Range(-.1f, .1f);
                    transform.position = new Vector2(orignalPosition.x + x, orignalPosition.y + y);
                }
                else
                {
                    if (Follow)
                    {
                        transform.position = orignalPosition;
                    }
                }
            }
            else
            {
                transform.position = new Vector2(10f, 10f); //Out of the way
            }
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
}