using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideToSideScript : MonoBehaviour
{
    bool Direction;
    float XTravel;
    float TravelSpeed;
    Vector3 Move;

    void Start()
    {
        XTravel = 0;
        Direction = false;
        TravelSpeed = .1f;
        Move = new Vector3(1f, 0f, 0f);
    }
    // Update is called once per frame
    void Update ()
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
}
