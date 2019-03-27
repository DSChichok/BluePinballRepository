using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss7Script : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip AudioClip_Ow;
    public AudioClip AudioClip_Laugh;
    public AudioClip AudioClip_Attack;
    public Animator anim;

    Vector2 OriginalPosition;
    int HitsTilDeath = 60;
    int Hurting;
    int AnimationPhase = 0;
    bool Defeat = false;
    bool DefeatSignal = false;
    float x;
    float y;
    int AttackCount = 0;
    float SecondsWait = 8;

    public bool GiveOkayToDoShit = false;

    // Use this for initialization
    void Start()
    {
        AttackCount = 0;
        transform.position = new Vector2(0, 1f);
        Audio.loop = false;
        HitsTilDeath = 60;
        Hurting = 0;
        Defeat = false;
        OriginalPosition = transform.position;
        StartCoroutine(Gimmick());
    }

    // Update is called once per frame
    void Update()
    {
        if (HitsTilDeath < 31)
        {
            SecondsWait = 4f;
        }

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
            yield return new WaitForSeconds(SecondsWait);
            if (GiveOkayToDoShit)
            {
                if (!Defeat)
                {
                    if (AttackCount == 0)
                    {
                        if (GameObject.FindGameObjectsWithTag("Ball").Length != 0)
                        {
                            foreach (GameObject min in GameObject.FindGameObjectsWithTag("Respawn"))
                            {
                                min.GetComponent<MinionsAndBossesScript>().SpawnRocks();
                            }
                        }
                        Audio.clip = AudioClip_Laugh;
                        Audio.Play();
                    }
                    else if (AttackCount == 1)
                    {
                        if (GameObject.FindGameObjectsWithTag("Ball").Length != 0)
                        {
                            foreach (GameObject min in GameObject.FindGameObjectsWithTag("Respawn"))
                            {
                                min.GetComponent<MinionsAndBossesScript>().SpawnSpear();
                            }
                            Audio.clip = AudioClip_Attack;
                            Audio.Play();
                        }
                        else
                        {
                            Audio.clip = AudioClip_Laugh;
                            Audio.Play();
                        }
                    }
                    else if (AttackCount == 2)
                    {
                        if (GameObject.FindGameObjectsWithTag("Ball").Length != 0)
                        {
                            foreach (GameObject min in GameObject.FindGameObjectsWithTag("Respawn"))
                            {
                                min.GetComponent<MinionsAndBossesScript>().SpawnHeart();
                            }
                        }
                        Audio.clip = AudioClip_Laugh;
                        Audio.Play();
                    }
                    else if (AttackCount == 3)
                    {
                        if (GameObject.FindGameObjectsWithTag("Ball").Length != 0)
                        {
                            foreach (GameObject min in GameObject.FindGameObjectsWithTag("Respawn"))
                            {
                                min.GetComponent<MinionsAndBossesScript>().SpawnNumbers();
                                min.GetComponent<MinionsAndBossesScript>().SpawnNumbers();
                            }
                            Audio.clip = AudioClip_Attack;
                            Audio.Play();
                        }
                        else
                        {
                            Audio.clip = AudioClip_Laugh;
                            Audio.Play();
                        }
                    }

                    AttackCount++;
                    if (AttackCount > 3)
                    {
                        AttackCount = 0;
                    }
                }
            }
        }
    }
}