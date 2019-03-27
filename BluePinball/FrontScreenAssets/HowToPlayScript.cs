using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        transform.position = new Vector2(20f, 20f);
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
