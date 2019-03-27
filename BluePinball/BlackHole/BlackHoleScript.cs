using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackHoleScript : MonoBehaviour
{
    public GameObject Shield;
    public GameObject StopDetection;
    public GameObject LaunchNewBall;
    public GameObject Plunge;
    public GameObject MultiB;
    public GameObject ScoreKeeper;
    public AudioSource Audio;
    public AudioClip AudioClip_BallLocked;
    public AudioClip AudioClip_Multiball;
    public Text BallStatus;
    public bool Traveling;
    public bool HoleReady;
    public bool AlreadyPorted;

    int BallsEaten;
    float XTravel;
    bool Direction;
    float TravelSpeed;
    Vector3 Move;

    // Use this for initialization
    void Start ()
    {
        Audio.loop = false;
        Reset();
    }

    public void Reset()
    {
        AlreadyPorted = false;
        HoleReady = false;
        XTravel = 0;
        Traveling = true;
        BallsEaten = 0;
        Direction = false;
        TravelSpeed = .1f;
        transform.position = new Vector2(XTravel, 3.2f);
        Move = new Vector3(1f, 0f, 0f);

    }

    // Update is called once per frame
    void Update ()
    {
        if (Traveling)
        {
            if (Direction)
            {
                
                XTravel += TravelSpeed;
                transform.position += Move * TravelSpeed;
                transform.position = new Vector3(transform.position.x, transform.position.y, 100f);

                if (XTravel > 3f)
                {
                    Direction = !Direction;
                }
            }
            else
            {
                XTravel -= TravelSpeed;
                transform.position -= Move * TravelSpeed;
                transform.position = new Vector3(transform.position.x, transform.position.y, 100f);

                if (XTravel < -3f)
                {
                    Direction = !Direction;
                }
            }
            
        }
        else
        {
            if (!AlreadyPorted)
            {
                AlreadyPorted = true;
                transform.position = new Vector2(10f, 10f);
                //BallsEaten = 0;
            }
            if (GameObject.FindGameObjectsWithTag("Ball").Length < 2)
            {
                //Reset the Black Hole and its Shield
                Reset();
                Shield.GetComponent<BlackHoleOuterScript>().Reset();
                HoleReady = false;
            }

        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (HoleReady)
        {
            //Add to Score
            ScoreKeeper.GetComponent<ScoreScript>().AddToScore(10);

            //Stop ball detection for now
            Shield.GetComponent<BlackHoleOuterScript>().SuckedSound();
            BallsEaten++;

            if (BallsEaten < 4)
            {
                //Delete the ball (there should be only one ball on the field at this time anyway)
                StopDetection.GetComponent<BallDetectorScript>().StartCheckingForBalls = false;
                StartCoroutine(ShrinkAndKillBall());

                //Play Ball Locked
                Audio.clip = AudioClip_BallLocked;
                Audio.Play();

                //Display Ball Locked
                BallStatus.text = "Ball Locked";

                //Reset for the next shield
                HoleReady = false;
                //Shield.GetComponent<BlackHoleOuterScript>().Reset();
            }
            else
            {
                HoleReady = false;
                Traveling = false;
                TriggerMultiball();

                //Play Multiball
                Audio.clip = AudioClip_Multiball;
                Audio.Play();

                //Display Mulitball
                BallStatus.text = "Mulitball!";
                StartCoroutine(KillMultiball());
            }
        }
    }

    IEnumerator KillMultiball()
    {
        yield return new WaitForSeconds(2f);
        BallStatus.text = "";
    }

    IEnumerator ShrinkAndKillBall()
    {
        //Shrink
        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Ball"))
        {
            ball.GetComponent<BallScript>().StartShrinking();
        }
        yield return new WaitForSeconds(1);

        //Kill
        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Ball"))
        {
            Destroy(ball);
        }

        //Launch New Ball
        Plunge.GetComponent<PlungerScript>().Reset();
        LaunchNewBall.GetComponent<MasterBackgroundScript>().TriggerSwitch();

        //Reset the Black Hole and its Shield
        AlreadyPorted = false;
        transform.position = new Vector2(XTravel, 3.2f);
        Move = new Vector3(1f, 0f, 0f);
        Shield.GetComponent<BlackHoleOuterScript>().Reset();
    }

    void TriggerMultiball()
    {
        MultiB.GetComponent<MultiballLauncherScript>().LaunchMultiball();
        Traveling = false;
    }
}
