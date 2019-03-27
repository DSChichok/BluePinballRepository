using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreTitleAnimScript : MonoBehaviour
{
    bool Direction;
    float TravelSpeed;
    Vector3 Move;
    Vector3 MoveY;
    float XTravel;
    float YTravel;
    bool YDirection;

    // Use this for initialization
    void Start ()
    {
        Direction = false;
        TravelSpeed = .01f;
        Move = new Vector3(1f, 0f, 0f);
        XTravel = Random.Range(-.2f, .2f);

        YDirection = false;
        YTravel = Random.Range(-.2f, .2f);
        MoveY = new Vector3(0f, 1f, 0f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Direction)
        {

            XTravel += TravelSpeed;
            transform.position += Move * TravelSpeed;
            transform.position = new Vector3(transform.position.x, transform.position.y, 100f);

            if (XTravel > .2f)
            {
                Direction = !Direction;
            }
        }
        else
        {
            XTravel -= TravelSpeed;
            transform.position -= Move * TravelSpeed;
            transform.position = new Vector3(transform.position.x, transform.position.y, 100f);

            if (XTravel < -.2f)
            {
                Direction = !Direction;
            }
        }

        if (YDirection)
        {

            YTravel += TravelSpeed;
            transform.position += MoveY * TravelSpeed;
            transform.position = new Vector3(transform.position.x, transform.position.y, 100f);

            if (YTravel > .2f)
            {
                YDirection = !YDirection;
            }
        }
        else
        {
            YTravel -= TravelSpeed;
            transform.position -= MoveY * TravelSpeed;
            transform.position = new Vector3(transform.position.x, transform.position.y, 100f);

            if (YTravel < -.2f)
            {
                YDirection = !YDirection;
            }
        }
    }
}
