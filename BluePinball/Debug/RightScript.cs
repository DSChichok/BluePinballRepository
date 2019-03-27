using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void TeleportDown()
    {
        transform.position = new Vector2(1.5f, 2f);
    }

    public void TeleportUp()
    {
        transform.position = new Vector2(1.5f, 1f);
    }
}