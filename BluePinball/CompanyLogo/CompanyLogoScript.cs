using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class CompanyLogoScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        CheckAndOrCreateHighScores();
        StartCoroutine(StartGame());
    }

    void CheckAndOrCreateHighScores()
    {
        Debug.Log(Application.persistentDataPath + "/HighScore.dsy");
        string path = Application.persistentDataPath + "/HighScore.dsy";
        if (!File.Exists(path))
        {
            StreamWriter sw = System.IO.File.CreateText(path);
            sw.Close();
            System.IO.File.WriteAllText(path, "DSC5000\nDSC4000\nDSC3000\nDSC2000\nDSC1000\n0");
        }
    }

    IEnumerator StartGame()
    {
        //4, more than enough time to check the high score file if it exists
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("TitleScreenScene");
    }
}