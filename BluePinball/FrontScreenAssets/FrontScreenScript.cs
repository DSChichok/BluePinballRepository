using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontScreenScript : MonoBehaviour
{

	// Front and center
	void Start ()
    {
        transform.position = new Vector2(0f, 0f);
    }

    public void ReturnToHome()
    {
        transform.position = new Vector2(0f, 0f);
    }

    public void GoAway()
    {
        transform.position = new Vector2(20f, 20f);
    }
}