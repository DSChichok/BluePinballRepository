using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCoverScript : MonoBehaviour
{
    public GameObject BossDefeat;
    public GameObject NextStage;
    public GameObject NextMusic;
    public GameObject TopLoader;
    public GameObject Plunger;
    public GameObject ScoreKeep;
    public GameObject BossLoader;
    public GameObject BackgroundChange;

    public AudioSource Audio;
    public AudioClip AudioClip_Boss7Slam;

    bool TriggerBlock;
    bool Climb;
    SpriteRenderer spRend;
    Color col;
    float ClimbSpeed;
    int BossesTotal = 0;

    // Use this for initialization
    void Start ()
    {
        Audio.loop = false;
        Audio.clip = AudioClip_Boss7Slam;
        BossesTotal = 0;
        spRend = transform.GetComponent<SpriteRenderer>();
        TriggerBlock = false;
        Climb = true;
        ClimbSpeed = .01f;
    }

    public void TriggerWhiteBlock()
    {
        ScoreKeep.GetComponent<ScoreScript>().AddToScore(10000);
        TriggerBlock = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (TriggerBlock)
        {
            if (Climb)
            {
                StartClimbing();
            }
            else
            {
                StartDecending();
            }
        }
    }

    void StartClimbing()
    {
        col = spRend.color;
        //Debug.Log("sadf " + col.a);
        if (col.a < .89)
        {
            col.a += ClimbSpeed;
            spRend.color = col;
        }
        else
        {
            //Equalize it
            col.a = 1;
            spRend.color = col;

            //We're at full white block, trigger the death of all minions and boss
            BossDefeat.GetComponent<BossDefeaterScript>().FinishBossDefeat();

            //Change Background
            BackgroundChange.GetComponent<TopScreenScript>().ChangeBackground();

            //Reverse the white
            Climb = false;
        }
    }

    void StartDecending()
    {
        col = spRend.color;
        if (col.a > .02)
        {
            col.a -= ClimbSpeed;
            spRend.color = col;
        }
        else
        {
            //Equalize it
            col.a = 0;
            spRend.color = col;
            TriggerBlock = false;
            Climb = true;

            BossesTotal++;
            if (BossesTotal < 6)
            {
                //Start next stage and music
                NextStage.GetComponent<MinionsAndBossesScript>().StartNextStage();
                NextMusic.GetComponent<MusicPlayerScript>().PlayNextTrack();

                //Launch new ball
                TopLoader.GetComponent<MasterBackgroundScript>().TriggerSwitch();
                Plunger.GetComponent<PlungerScript>().Reset();
            }
            else if (BossesTotal == 6)
            {
                //Final Boss Time
                StartCoroutine(GiveTauntAChance());
            }
            else  //Last Boss killed, reset everything
            {
                NextStage.GetComponent<MinionsAndBossesScript>().StartNextStage();
                NextMusic.GetComponent<MusicPlayerScript>().PlayNextTrack();
                TopLoader.GetComponent<MasterBackgroundScript>().TriggerSwitch();
                Plunger.GetComponent<PlungerScript>().Reset();
                BossLoader.GetComponent<MinionsAndBossesScript>().Reset();
                ScoreKeep.GetComponent<ScoreScript>().AddToScore(70000);
                BossesTotal = 0;
            }
        }
    }

    IEnumerator GiveTauntAChance()
    {
        //Wait 1 second
        yield return new WaitForSeconds(1f);

        //Play Crush Sound and teleport Boss in
        BossLoader.GetComponent<MinionsAndBossesScript>().FinalBossGo();
        Audio.Play();
        yield return new WaitForSeconds(4f);

        //Start Sequence
        NextMusic.GetComponent<MusicPlayerScript>().PlayNextTrack();
        TopLoader.GetComponent<MasterBackgroundScript>().TriggerSwitch();
        Plunger.GetComponent<PlungerScript>().Reset();
        BossLoader.GetComponent<MinionsAndBossesScript>().LoadFinalBossMinions();

        //Give Boss Okay to do shit
        foreach (GameObject boss in GameObject.FindGameObjectsWithTag("Boss"))
        {
            boss.GetComponent<Boss7Script>().GiveOkayToDoShit = true;
        }
    }
}