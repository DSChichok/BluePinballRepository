using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallDetectorScript : MonoBehaviour
{
    public GameObject NewBall;
    public GameObject Screen;
    public GameObject BallLife;
    public GameObject Events;
    public bool StartCheckingForBalls;
    public bool SaveBall;
    public AudioSource Audio;
    public AudioClip AudioClip_OhNo;
    public Text BallLoss;
    public bool BallAlreadyLost;

    bool GiveDetectionAChance;

	// Use this for initialization
	void Start ()
    {
        Audio.loop = false;
        Reset();
        BallLoss.text = "";
    }

    public void Reset()
    {
        BallAlreadyLost = false;
        StartCheckingForBalls = false;
        GiveDetectionAChance = false;
        SaveBall = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (StartCheckingForBalls)
        {
            if (!GiveDetectionAChance)
            {
                GiveDetectionAChance = true;
                StartCoroutine(DetectBalls());
            }
        }

        //Kill out of bounds balls
        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Ball"))
        {
            if (ball.transform.position.y < -7f)
            {
                Destroy(ball);
            }
            //This will reintroduce balls that have left the stadium on the side by a push out, which isn't technically ball death
            else if (ball.transform.position.x > 4f) 
            {
                GameObject bally = Instantiate(NewBall, new Vector2(3f, 3f), Quaternion.identity);
                bally.transform.localScale = new Vector3(0.1f, 0.1f, 0f);
                Destroy(ball);
            }
            else if (ball.transform.position.x < -4f)
            {
                GameObject bally = Instantiate(NewBall, new Vector2(-3f, 3f), Quaternion.identity);
                bally.transform.localScale = new Vector3(0.1f, 0.1f, 0f);
                Destroy(ball);
            }
        }
    }

    IEnumerator DetectBalls()
    {
        //Giving the BallDetection a 1 second rest between checks
        yield return new WaitForSeconds(1);

        //Check if balls exist
        if (StartCheckingForBalls)
        {
            if (GameObject.FindGameObjectsWithTag("Ball").Length == 0)
            {
                if (SaveBall)
                {

                }
                else
                {
                    //Start Ball Gone process
                    if (!BallAlreadyLost)
                    {
                        BallAlreadyLost = true;
                        Audio.clip = AudioClip_OhNo;
                        Audio.Play();

                        //Screen Shake and Star Showcasing Ball death stats
                        StartCoroutine(BallDeath());
                        StartCheckingForBalls = false;
                        GiveDetectionAChance = false;
                    }
                }
            }
        }

        //Done giving the detect ball a rest
        GiveDetectionAChance = false;
    }

    IEnumerator BallDeath()
    {
        //Shake Screen for half a second
        Screen.GetComponent<TopScreenScript>().Shake = true;
        yield return new WaitForSeconds(.5f);
        Screen.GetComponent<TopScreenScript>().Shake = false;
        Screen.GetComponent<TopScreenScript>().transform.position = new Vector2(0f, 0f); 

        //Show Ball lifetime stats for 3 seconds
        BallLoss.text = "Ball Lifetime Score:\n" + string.Format("{0:n0}", System.Convert.ToInt64(BallLife.GetComponent<ScoreScript>().DaSubScore));
        yield return new WaitForSeconds(3f);

        //Dissapear ball life stats and give signal to either 
        //launch next ball or start Game Over Sequence
        BallLoss.text = "";
        Events.GetComponent<EventTrackerScript>().LaunchNextBallOrGameOver();
        BallLife.GetComponent<ScoreScript>().DaSubScore = 0;
    }
}