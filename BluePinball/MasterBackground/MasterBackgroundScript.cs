using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterBackgroundScript : MonoBehaviour
{
    public GameObject TopB;
    public GameObject BottomB;
    public GameObject Plung;
    public GameObject BallLaunch;
    public GameObject LeftBut;
    public GameObject RightBut;
    public AudioSource Audio;
    public GameObject BallCheck;
    public AudioClip AudioClip_GunShot;
    public AudioClip AudioClip_ReverseShot;
    public AudioClip AudioClip_AnnouncerGo;
    public Text EraseAnyText;

    bool ShowBottom;
    bool ShowTop;
    float SpeedOfClimb;
    bool Switcher;

	// Use this for initialization
	void Start ()
    {
        Audio.loop = false;
        transform.position = new Vector2(0f, -5f);
        ShowBottom = false;
        ShowTop = false;
        SpeedOfClimb = 1f;
        Switcher = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(transform.position.y);
        //if (Input.GetKeyDown("space"))
        //{
        //    TriggerSwitch();
        //}

        if (ShowBottom)
        {
            SlideToBottom();
        }
        else if (ShowTop)
        {
            SlideToTop();
        }
	} 

    void SlideToBottom()
    {
        if (!AreSame(BottomB.transform.position.y, 0f) || BottomB.transform.position.y < 0f)
        {
            transform.position = new Vector2(0f, transform.position.y + SpeedOfClimb);
        }
        else
        {
            ShowBottom = false;
            transform.position = new Vector2(0f, 5f);  //This is to correct overtravel
            Plung.GetComponent<PlungerScript>().CheckCock = true;
            //We have arrived
            EraseAnyText.text = "";
            LeftBut.GetComponent<LeftButtonScript>().FreeToClick = false;
            RightBut.GetComponent<RightButtonScript>().FreeToClick = false;
        }
    }

    void SlideToTop()
    {
        if (!AreSame(TopB.transform.position.y, 0f) || TopB.transform.position.y > 0f)
        {
            transform.position = new Vector2(0f, transform.position.y - SpeedOfClimb);
        }
        else
        {
            ShowTop = false;
            transform.position = new Vector2(0f, -5f);  //This is to correct overtravel
          
            //We have arrived
            foreach (GameObject m in GameObject.FindGameObjectsWithTag("Minion"))
            {
                if (m.transform.name.Equals("Minion2Special(Clone)"))
                {
                    m.GetComponent<Minion2Script>().Follow = true;
                }
                else
                {
                    m.GetComponent<MinionScript>().Follow = true;
                }
            }
            SetBossToTrue();

            //Launch Ball
            BallLaunch.GetComponent<BallLauncherScript>().LaunchBall();
            LeftBut.GetComponent<LeftButtonScript>().FreeToClick = true;
            RightBut.GetComponent<RightButtonScript>().FreeToClick = true;
        }
    }

    bool AreSame(float a, float b)
    {
        return Math.Abs(a - b) < .01f;
    }

    public void TriggerSwitch()
    {
        Switcher = !Switcher;

        if (Switcher)
        {
            Audio.clip = AudioClip_GunShot;
            Audio.Play();
            ShowTop = true;
            StartCoroutine(AnnounceGo());

            //Give the ok to start checking for balls
            BallCheck.GetComponent<BallDetectorScript>().StartCheckingForBalls = true;
            BallCheck.GetComponent<BallDetectorScript>().BallAlreadyLost = false;
        }
        else
        {
            ShowBottom = true;
            Audio.clip = AudioClip_ReverseShot;
            Audio.Play();
            foreach (GameObject m in GameObject.FindGameObjectsWithTag("Minion"))
            {
                if (m.transform.name.Equals("Minion2Special(Clone)"))
                {
                    m.GetComponent<Minion2Script>().Follow = false;
                }
                else
                {
                    m.GetComponent<MinionScript>().Follow = false;
                }
            }
            SetBossToFalse();
            //    m.GetComponent<Boss1Script>().Follow = false;
            //}
        }
    }

    IEnumerator AnnounceGo()
    {
        //3 Second Chill time for user to absorb the atmosphere
        yield return new WaitForSeconds(Audio.clip.length);
        Audio.clip = AudioClip_AnnouncerGo;
        Audio.Play();
    }

    void SetBossToTrue()
    {
        foreach (GameObject m in GameObject.FindGameObjectsWithTag("Boss"))
        {
            if (m.transform.name.Equals("Boss02(Clone)"))
            {
                m.GetComponent<Boss2Script>().Follow = true;
            }
        }
    }

    void SetBossToFalse()
    {
        foreach (GameObject m in GameObject.FindGameObjectsWithTag("Boss"))
        {
            if (m.transform.name.Equals("Boss02(Clone)"))
            {
                m.GetComponent<Boss2Script>().Follow = false;
            }
        }
    }
}