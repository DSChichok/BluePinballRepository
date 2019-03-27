using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        transform.position = new Vector2( 0f, 1f );
    }

    // Update is called once per frame
    void Update ()
    {
        transform.Rotate(0, 0, -2f);
    }
}