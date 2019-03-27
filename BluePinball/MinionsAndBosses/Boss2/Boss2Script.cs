using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Script : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip AudioClip_Ow;
    public AudioClip AudioClip_Laugh;
    public bool Follow = true;
    public Animator anim;

    Vector2 OriginalPosition;
    int HitsTilDeath = 30;
    int Hurting;
    int AnimationPhase = 0;
    bool Defeat = false;
    bool DefeatSignal = false;
    float x;
    float y;

    // Use this for initialization
    void Start()
    {
        Follow = true;
        Audio.loop = false;
        HitsTilDeath = 30;
        Hurting = 0;
        Defeat = false;
        OriginalPosition = transform.position;
        StartCoroutine(TheGimmick());
    }

    // Update is called once per frame
    void Update()
    {
        if (Defeat)
        {
            if (!DefeatSignal)  //this is so it's calls these only once, don't have to keep reminding object is dead/dying
            {
                AnimationPhase = 2;
                DefeatSignal = true;

                foreach (GameObject min in GameObject.FindGameObjectsWithTag("Minion"))
                {
                    Destroy(min);
                }

                foreach (GameObject boss in GameObject.FindGameObjectsWithTag("BossDefeat"))
                {
                    boss.GetComponent<BossDefeaterScript>().StartBossDestroyedSequence();
                }
            }
            x = Random.Range(-.1f, .1f);
            y = Random.Range(-.1f, .1f);
            transform.position = new Vector2(OriginalPosition.x + x, OriginalPosition.y + y);
        }
        else if (Hurting > 0)
        {
            x = Random.Range(-.1f, .1f);
            y = Random.Range(-.1f, .1f);
            transform.position = new Vector2(OriginalPosition.x + x, OriginalPosition.y + y);
            AnimationPhase = 1;
        }
        else
        {
            if (Follow)
            {
                transform.position = OriginalPosition;
            }
            AnimationPhase = 0;
        }

        anim.SetInteger("Phase", AnimationPhase);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Add to score
        foreach (GameObject score in GameObject.FindGameObjectsWithTag("Score"))
        {
            score.GetComponent<ScoreScript>().AddToScore(100);
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
            Defeat = true;
        }
        StartCoroutine(Shaking());
    }

    IEnumerator Shaking()
    {
        Hurting++;
        yield return new WaitForSeconds(.2f);
        Hurting--;
    }

    IEnumerator TheGimmick()
    {
        while (!Defeat)
        {
            //Teleport every 2 seconds
            yield return new WaitForSeconds(2f);

            if (Follow && !Defeat)
            {
                //Teleport
                transform.position = new Vector2(Random.Range(-2f, 2f), Random.Range(-3f, 3f));
                OriginalPosition = transform.position;
                Audio.clip = AudioClip_Laugh;
                Audio.Play();
            }
        }
    }
}