using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        transform.position = new Vector2(20f, 20f);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void LoadTheGame()
    {
        transform.position = new Vector2(0f, 0f);
        StartCoroutine(StartTheGame());
    }

    IEnumerator StartTheGame()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("PinballScene");
    }
}