using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSonicScript : MonoBehaviour
{
    GameObject ThatObject;
    bool StartFollowing;

	// Use this for initialization
	void Start ()
    {
        //StartFollowing = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (StartFollowing)
        {
            transform.position = new Vector2(ThatObject.transform.position.x, ThatObject.transform.position.y);
        }
	}

    public void FollowThisObject(GameObject ThisObject)
    {
        ThatObject = ThisObject;
        StartFollowing = true;
    }
}