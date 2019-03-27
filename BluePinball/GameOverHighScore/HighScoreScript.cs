using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{
    //Legend
    //  0  1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36
    //  A  B  C  D  E  F  G  H  I  J  K  L  M  N  O  P  Q  R  S  T  U  V  W  X  Y  Z  0  1  2  3  4  5  6  7  8  9  _

    public GameObject Let1;
    public GameObject Let2;
    public GameObject Let3;
    public GameObject GameO;
    public Text YouPlaced;
    public Text ScoreDisplay;
    char[] Slot = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_".ToCharArray();
    string path;
    string[] lines;
    string Signature;

    string FirstSig;
    string SecondSig;
    string ThirdSig;
    string FourthSig;
    long FirstScore;
    long SecondScore;
    long ThirdScore;
    long FourthScore;
    long FifthScore;
    long UserScore;
    string Position;

    // Use this for initialization
    void Start ()
    {
        //Initialization
        GoAway();
        GameO.GetComponent<GameOverScript>().GoAway();

        //Get the scores
        path        = Application.persistentDataPath + "/HighScore.dsy";
        lines       = System.IO.File.ReadAllLines(path);
        FirstSig    = lines[0].Substring(0, 3);
        SecondSig   = lines[1].Substring(0, 3);
        ThirdSig    = lines[2].Substring(0, 3);
        FourthSig   = lines[3].Substring(0, 3);
        FirstScore  = Convert.ToInt64(lines[0].Substring(3, lines[0].Length - 3));
        SecondScore = Convert.ToInt64(lines[1].Substring(3, lines[1].Length - 3));
        ThirdScore  = Convert.ToInt64(lines[2].Substring(3, lines[2].Length - 3));
        FourthScore = Convert.ToInt64(lines[3].Substring(3, lines[3].Length - 3));
        FifthScore  = Convert.ToInt64(lines[4].Substring(3, lines[4].Length - 3));
        UserScore   = Convert.ToInt64(lines[5]);

        //Oh boy here we go
        if (UserScore > FifthScore)
        {
            Position = "5th";
            if (UserScore > FourthScore)
            {
                Position = "4th";
                if (UserScore > ThirdScore)
                {
                    Position = "3rd";
                    if (UserScore > SecondScore)
                    {
                        Position = "2nd";
                        if (UserScore > FirstScore)
                        {
                            Position = "1st";
                        }
                    }
                }
            }
            ScoreDisplay.text = string.Format("{0:n0}", UserScore);
            YouPlaced.text = "You Placed " + Position + "!";
            ReturnToHome();
        }
        else  //No High Score was made
        {
            GameO.GetComponent<GameOverScript>().ReturnToHome();
        }
    }

    public void HighScoreGenerateCollab()
    {
        //Lock the buttons
        Let1.GetComponent<Letter1Script>().AllowPress = false;
        Let2.GetComponent<Letter2Script>().AllowPress = false;
        Let3.GetComponent<Letter3Script>().AllowPress = false;

        //Switch Signature if the user just left it as 'AAA'
        if ( Let1.GetComponent<Letter1Script>().Position == 0 &&
             Let2.GetComponent<Letter2Script>().Position == 0 &&
             Let3.GetComponent<Letter3Script>().Position == 0 )
        {
            Let1.GetComponent<Letter1Script>().Position = 3;
            Let2.GetComponent<Letter2Script>().Position = 18;
            Let3.GetComponent<Letter3Script>().Position = 2;
        }

        //Install New High Score
        Signature = Slot[Let1.GetComponent<Letter1Script>().Position].ToString() 
                  + Slot[Let2.GetComponent<Letter2Script>().Position].ToString()
                  + Slot[Let3.GetComponent<Letter3Script>().Position].ToString();
        string[] installer = new string[] { "", "", "", "", "" };
        long[]   scores    = new long[]   { FirstScore, SecondScore, ThirdScore, FourthScore, 0 };
        string[] sigs      = new string[] { FirstSig, SecondSig, ThirdSig, FourthSig };
        bool AlreadyInstalled = false;
        int subI = 0;
        for( int i = 0; i < 5; i++ )
        {
            if (AlreadyInstalled)
            {
                installer[i] = sigs[subI] + scores[subI];
                subI++;
            }
            else
            {
                if (UserScore > scores[subI])
                {
                    AlreadyInstalled = true;
                    installer[i] = Signature + UserScore;
                }
                else
                {
                    installer[i] = sigs[subI] + scores[subI];
                    subI++;
                    
                }
            }
        }
        //Finally Install
        System.IO.File.WriteAllText( path, installer[0] + "\n" + installer[1] + "\n" + installer[2] + "\n" + installer[3] + "\n" + installer[4] + "\n0" );

        //Start Game Over Sequence
        StartCoroutine(TakeTimeToShowGameOver());
    }

    void ReturnToHome()
    {
        transform.position = new Vector2(0f, 0f);
    }

    void GoAway()
    {
        transform.position = new Vector2(20f, 20f);
    }

    IEnumerator TakeTimeToShowGameOver()
    {
        yield return new WaitForSeconds(3);
        GoAway();
        GameO.GetComponent<GameOverScript>().ReturnToHome();
    }
}