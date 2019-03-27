using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerScript : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip AudioClip_Stage1;
    public AudioClip AudioClip_Stage2;
    public AudioClip AudioClip_Stage3;
    public AudioClip AudioClip_Stage4;
    public AudioClip AudioClip_Stage5;
    public AudioClip AudioClip_Stage6;
    public AudioClip AudioClip_Boss;
    public AudioClip AudioClip_FinalBoss;

    int track = 0;

    // Use this for initialization
    void Start ()
    {
        Audio.loop = true;
        Audio.clip = AudioClip_Stage1;
        Audio.Play();
    }

    public void StopMusic()
    {
        Audio.Stop();
    }

    public void PlayNextTrack()
    {
        track++;
        if ( track > 6 )
        {
            track = 0;
        }

        switch (track)
        {
            case 0:
                Audio.clip = AudioClip_Stage1;
                break;
            case 1:
                Audio.clip = AudioClip_Stage2;
                break;
            case 2:
                Audio.clip = AudioClip_Stage3;
                break;
            case 3:
                Audio.clip = AudioClip_Stage4;
                break;
            case 4:
                Audio.clip = AudioClip_Stage5;
                break;
            case 5:
                Audio.clip = AudioClip_Stage6;
                break;
            case 6:
                Audio.clip = AudioClip_FinalBoss;
                break;
            default:
                Debug.Log("Not Supposed to be here");
                break;
        }
        Audio.Play();
    }

    public void PlayBossTrack()
    {
        Audio.clip = AudioClip_Boss;
        Audio.Play();
    }
}