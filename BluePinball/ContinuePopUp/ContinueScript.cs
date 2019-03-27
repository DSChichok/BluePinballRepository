using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueScript : MonoBehaviour
{
    public GameObject EventTrack;

	// Use this for initialization
	void Start ()
    {
        transform.position = new Vector2( 5000f, 5000f );
	}

    public void GameOverMet()
    {
        transform.position = new Vector2(0f, 0f);
    }

    public void YesChoice()
    {
        transform.position = new Vector2(5000f, 5000f);
    }

    public void NoChoice()
    {
        transform.position = new Vector2(5000f, 5000f);
    }
}