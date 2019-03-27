using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text ScoreDisplay;
    public long DaScore;
    public long DaSubScore;

    string CommaScore;

	// Use this for initialization
	void Start ()
    {
        DaScore = 0;
        DaSubScore = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        CommaScore = string.Format("{0:n0}", System.Convert.ToInt32( DaScore ));
        ScoreDisplay.text = CommaScore;
    }

    public void AddToScore( long Addition )
    {
        DaScore += Addition;
        DaSubScore += Addition;
    }
}