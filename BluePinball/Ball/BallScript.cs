using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    bool Shrink;

	// Use this for initialization
	void Start ()
    {
        Shrink = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Shrink)
        {
            //Shrinking isn't working so decided to just teleport the ball out of the way
            transform.position = new Vector2(0f, 50f);
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //    Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //    transform.position = new Vector2(objPosition.x, objPosition.y);
        //}
    }

    public void StartShrinking()
    {
        Shrink = true;
        transform.GetComponent<Rigidbody2D>().isKinematic = true;
    }
}