using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject TextRot;

	// Use this for initialization
	void Start ()
    {
        GoAway();
    }
	
	// Update is called once per frame
	void Update ()
    {
        TextRot.transform.Rotate(0, 0, -3f);
    }

    public void ReturnToHome()
    {
        transform.position = new Vector2(0f, 0f);
        StartCoroutine(TakeTimeTillLoadingTitle());
    }

    public void GoAway()
    {
        transform.position = new Vector2(20f, 20f);
    }

    IEnumerator TakeTimeTillLoadingTitle()
    {
        //5 seconds to show Game Over and then load title screen
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("TitleScreenScene");
    }
}