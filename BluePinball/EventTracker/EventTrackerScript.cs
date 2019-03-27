using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventTrackerScript : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip AudioClip_Ready;
    public AudioClip AudioClip_Ball1;
    public AudioClip AudioClip_Ball2;
    public AudioClip AudioClip_Ball3;
    public GameObject Plung;
    public GameObject Slider;
    public GameObject Scorer;
    public GameObject Continue;
    public Text Announce;
    public Text Ballsy;
    bool ScoreNull = false;
    int BallsLeft = 2;

	// Use this for initialization
	void Start ()
    {
        //Never let audio announcer clips repeat
        Audio.loop = false;
        Ballsy.text = "3";

        //Wait a little to allow player to absorb the atmosphere then begin launch
        StartCoroutine(StartTheGame());
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    IEnumerator StartTheGame()
    {
        //3 Second Chill time for user to absorb the atmosphere
        yield return new WaitForSeconds(2);

        //Announcer says "Ball 1"
        Announce.text = "Ball 1";
        Audio.clip = AudioClip_Ball1;
        Audio.Play();
        yield return new WaitForSeconds(Audio.clip.length);
        yield return new WaitForSeconds(1);

        //Announcer says "Ready?"
        Announce.text = "Ready?";
        Audio.clip = AudioClip_Ready;
        Audio.Play();
        yield return new WaitForSeconds(Audio.clip.length);
        Announce.text = "";

        //Slide Down
        Slider.GetComponent<MasterBackgroundScript>().TriggerSwitch();
    }

    public void ReplenishBalls()
    {
        BallsLeft = 2;
        Ballsy.text = "" + (BallsLeft + 1);
        StartCoroutine(ReplenishTimer());
    }

    //Player chose to continue after GameOver conditions were met
    public void ReplenishEasy()
    {
        BallsLeft = 2;
        Ballsy.text = "" + (BallsLeft + 1);
        ScoreNull = true;
        Plung.GetComponent<PlungerScript>().Reset();
        StartCoroutine(StartTheGame());
    }

    IEnumerator ReplenishTimer()
    {
        //5 seconds of flashing ball repl
        Announce.text = "Balls replenished!";
        yield return new WaitForSeconds(.5f);
        Announce.text = "";
        yield return new WaitForSeconds(.5f);
        Announce.text = "Balls replenished!";
        yield return new WaitForSeconds(.5f);
        Announce.text = "";
        yield return new WaitForSeconds(.5f);
        Announce.text = "Balls replenished!";
        yield return new WaitForSeconds(.5f);
        Announce.text = "";
        yield return new WaitForSeconds(.5f);
        Announce.text = "Balls replenished!";
        yield return new WaitForSeconds(.5f);
        Announce.text = "";
        yield return new WaitForSeconds(.5f);
        Announce.text = "Balls replenished!";
        yield return new WaitForSeconds(.5f);
        Announce.text = "";
        yield return new WaitForSeconds(.5f);
    }


    public void LaunchNextBallOrGameOver()
    {
        BallsLeft--;
        Ballsy.text = "" + (BallsLeft + 1);

        if (BallsLeft > -1)
        {
            StartNextBall();
        }
        else
        {
            Continue.GetComponent<ContinueScript>().GameOverMet();
        }
    }

    void StartNextBall()
    {
        Plung.GetComponent<PlungerScript>().Reset();

        if (BallsLeft == 1)  //launching ball 2
        {
            Announce.text = "Ball 2";
            Audio.clip = AudioClip_Ball2;
            Audio.Play();
        }
        else if (BallsLeft == 0) //launching ball 3
        {
            Announce.text = "Ball 3";
            Audio.clip = AudioClip_Ball3;
            Audio.Play();
        }
        StartCoroutine(FinishLaunchingBall());
    }

    IEnumerator FinishLaunchingBall()
    {
        //Allow Announcer to finish announcing the next ball
        yield return new WaitForSeconds(Audio.clip.length);
        yield return new WaitForSeconds(1);

        //Announcer says "Ready?"
        Announce.text = "Ready?";
        Audio.clip = AudioClip_Ready;
        Audio.Play();
        yield return new WaitForSeconds(Audio.clip.length);

        //Slide Down
        Announce.text = "";
        Slider.GetComponent<MasterBackgroundScript>().TriggerSwitch();
    }

    public void StartGameOver()
    {
        Announce.text = "Game Over";
        Debug.Log("GameOver");
        StartCoroutine(GOSequence());
    }

    IEnumerator GOSequence()
    {
        //Tell Player Game Over
        Announce.text = "Game Over";

        if (!ScoreNull)
        {
            //Save Score (next scene handles high scores if any)
            long FinalScore = Scorer.GetComponent<ScoreScript>().DaScore;
            string path = Application.persistentDataPath + "/HighScore.dsy";
            string[] lines = System.IO.File.ReadAllLines(path);
            System.IO.File.WriteAllText(path, lines[0] + "\n" + lines[1] + "\n" + lines[2] + "\n" + lines[3] + "\n" + lines[4] + "\n" + FinalScore);
        }

        //Give Player time to absorb they just got game over
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("GameOverScene");
    }
}