using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleFollow1Script : MonoBehaviour
{
    public GameObject FollowThis;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(0, 0, 2f);

        transform.position = new Vector2( FollowThis.transform.position.x, FollowThis.transform.position.y );
    }
}
