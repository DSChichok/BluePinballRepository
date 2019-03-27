using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosivePlacer : MonoBehaviour
{
    public GameObject explos;
    Vector2 mousePosition;
    Vector2 objPosition;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            GameObject m = Instantiate(explos, objPosition, Quaternion.identity);
            m.transform.localScale = new Vector3(3f, 3f, 3f);
        }
    }
}
