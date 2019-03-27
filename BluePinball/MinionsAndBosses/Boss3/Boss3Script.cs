using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Script : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip AudioClip_Ow;
    public AudioClip AudioClip_Laugh;
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
        transform.position = new Vector2(0, 1f);
        Audio.loop = false;
        HitsTilDeath = 30;
        Hurting = 0;
        Defeat = false;
        OriginalPosition = transform.position;
        StartCoroutine(Gimmick());
    }

    // Update is called once per frame
    void Update()
    {
        if (Defeat)
        {
            if (!DefeatSignal)
            {
                AnimationPhase = 2;
                DefeatSignal = true;

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

    IEnumerator Gimmick()
    {
        while (!Defeat)
        {
            //Teleport in rocks every 3 seconds
            yield return new WaitForSeconds(3f);

            if (!Defeat)
            {
                foreach (GameObject min in GameObject.FindGameObjectsWithTag("Respawn"))
                {
                    min.GetComponent<MinionsAndBossesScript>().SpawnRocks();
                }

                Audio.clip = AudioClip_Laugh;
                Audio.Play();
            }
        }
    }
}