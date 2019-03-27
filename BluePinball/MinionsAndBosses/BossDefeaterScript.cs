using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDefeaterScript : MonoBehaviour
{
    public GameObject MusicPlay;
    public GameObject WhiteBack;
    public GameObject BallDetect;
    public GameObject Exploder;
    public GameObject Shake;
    public GameObject Scorer;
    public GameObject BallsReplenish;

    //Audio Clips
    public AudioSource Audio;
    public AudioClip Audioclip_Boss1Announce;
    public AudioClip Audioclip_Boss2Announce;
    public AudioClip Audioclip_Boss3Announce;
    public AudioClip Audioclip_Boss4Announce;
    public AudioClip Audioclip_Boss5Announce;
    public AudioClip Audioclip_Boss6Announce;
    public AudioClip Audioclip_Boss7Announce;
    public AudioClip Audioclip_Boss1Defeat;
    public AudioClip Audioclip_Boss2Defeat;
    public AudioClip Audioclip_Boss3Defeat;
    public AudioClip Audioclip_Boss4Defeat;
    public AudioClip Audioclip_Boss5Defeat;
    public AudioClip Audioclip_Boss6Defeat;
    public AudioClip Audioclip_Boss7Defeat;

    private int BossCount = 0;

    // Use this for initialization
    void Start ()
    {
        Audio.loop = false;
    }

    public void StartBossDestroyedSequence()
    {
        //Flash Balls replenish
        BallsReplenish.GetComponent<EventTrackerScript>().ReplenishBalls();

        //Stop the Music
        MusicPlay.GetComponent<MusicPlayerScript>().StopMusic();

        //Stop ball detection
        BallDetect.GetComponent<BallDetectorScript>().StartCheckingForBalls = false;

        //Start explosions
        Exploder.GetComponent<ExplosionsScript>().StartExplosions();

        //Delete all balls
        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Ball"))
        {
            Destroy(ball);
        }

        //Timing
        StartCoroutine(TimedItems());
    }

    IEnumerator TimedItems()
    {
        //4 seconds of boss yell
        PlayBossYell();
        yield return new WaitForSeconds(4f);

        //Shake screen for 2 seconds
        Shake.GetComponent<TopScreenScript>().BossDown = true;
        yield return new WaitForSeconds(2f);

        //White screen
        WhiteBack.GetComponent<WhiteCoverScript>().TriggerWhiteBlock();

        //Wait for screen to be completely white then do FinishBossDefeat()
    }

    public void FinishBossDefeat()
    {
        //Delete boss and minions and weapons
        foreach (GameObject boss in GameObject.FindGameObjectsWithTag("Boss"))
        {
            Destroy(boss);
        }
        foreach (GameObject minion in GameObject.FindGameObjectsWithTag("Minion"))
        {
            Destroy(minion);
        }
        foreach (GameObject weapon in GameObject.FindGameObjectsWithTag("Weapon"))
        {
            Destroy(weapon);
        }

        //Stop explosions
        Exploder.GetComponent<ExplosionsScript>().StopExplosions();

        //Stop shaking
        Shake.GetComponent<TopScreenScript>().BossDown = false;

        //Wait for white to be completely gone then load next wave
    }

    void PlayBossYell()
    {
        switch (BossCount)
        {
            case 0:
                Audio.clip = Audioclip_Boss1Defeat;
                break;
            case 1:
                Audio.clip = Audioclip_Boss2Defeat;
                break;
            case 2:
                Audio.clip = Audioclip_Boss3Defeat;
                break;
            case 3:
                Audio.clip = Audioclip_Boss4Defeat;
                break;
            case 4:
                Audio.clip = Audioclip_Boss5Defeat;
                break;
            case 5:
                Audio.clip = Audioclip_Boss6Defeat;
                break;
            case 6:
                Audio.clip = Audioclip_Boss7Defeat;
                break;
            default:
                Debug.Log("Unrachable Boss Yell Code");
                break;
        }
        Audio.Play();
        Scorer.GetComponent<ScoreScript>().AddToScore(10000);

        BossCount++;
        if (BossCount > 6)
        {
            BossCount = 0;
        }
    }

    public void PlayBossAnnounce()
    {
        switch (BossCount)
        {
            case 0:
                Audio.clip = Audioclip_Boss1Announce;
                break;
            case 1:
                Audio.clip = Audioclip_Boss2Announce;
                break;
            case 2:
                Audio.clip = Audioclip_Boss3Announce;
                break;
            case 3:
                Audio.clip = Audioclip_Boss4Announce;
                break;
            case 4:
                Audio.clip = Audioclip_Boss5Announce;
                break;
            case 5:
                Audio.clip = Audioclip_Boss6Announce;
                break;
            case 6:
                Audio.clip = Audioclip_Boss7Announce;
                break;
            default:
                Debug.Log("Unrachable Boss Announce Code");
                break;
        }
        Audio.Play();
    }
}