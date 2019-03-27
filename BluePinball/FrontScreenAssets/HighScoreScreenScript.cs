using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScreenScript : MonoBehaviour
{
    string path;
    public Text First;
    public Text Second;
    public Text Third;
    public Text Fourth;
    public Text Fifth;

    // Use this for initialization
    void Start()
    {
        path = Application.persistentDataPath + "/HighScore.dsy";
        transform.position = new Vector2(20f, 20f);

        //Set High Scores
        HighScoreSetter();
    }

    public void ReturnToHome()
    {
        transform.position = new Vector2(0f, 0f);
    }

    public void GoAway()
    {
        transform.position = new Vector2(20f, 20f);
    }

    void HighScoreSetter()
    {
        //Grab all the scores
        string[] lines = System.IO.File.ReadAllLines(path);

        //This separation was done for readability
        string FirstPlaceGuy = lines[0].Substring(0, 3);
        string SecondPlaceGuy = lines[1].Substring(0, 3);
        string ThirdPlaceGuy = lines[2].Substring(0, 3);
        string FourthPlaceGuy = lines[3].Substring(0, 3);
        string FifethPlaceGuy = lines[4].Substring(0, 3);

        //This separation was done for readability
        string FirstPlaceScore = string.Format("{0:n0}", System.Convert.ToInt64(lines[0].Substring(3, lines[0].Length - 3)));
        string SecondPlaceScore = string.Format("{0:n0}", System.Convert.ToInt64(lines[1].Substring(3, lines[1].Length - 3)));
        string ThirdPlaceScore = string.Format("{0:n0}", System.Convert.ToInt64(lines[2].Substring(3, lines[2].Length - 3)));
        string FourthPlaceScore = string.Format("{0:n0}", System.Convert.ToInt64(lines[3].Substring(3, lines[3].Length - 3)));
        string FifthPlaceScore = string.Format("{0:n0}", System.Convert.ToInt64(lines[4].Substring(3, lines[4].Length - 3)));

        //1st
        First.text = "1st: " + FirstPlaceGuy + " " + FirstPlaceScore;

        //2nd
        Second.text = "2nd: " + SecondPlaceGuy + " " + SecondPlaceScore;

        //3rd
        Third.text = "3rd: " + ThirdPlaceGuy + " " + ThirdPlaceScore;

        //4th
        Fourth.text = "4th: " + FourthPlaceGuy + " " + FourthPlaceScore;

        //5th
        Fifth.text = "5th: " + FifethPlaceGuy + " " + FifthPlaceScore;

    }
}
