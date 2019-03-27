using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiballLauncherScript : MonoBehaviour
{
    public GameObject Ball;
    public AudioSource Audio;
    public GameObject ScoreKeeper;
    public AudioClip AudioClip_Multiball;

    void Start()
    {
        Audio.loop = false;
        Audio.clip = AudioClip_Multiball;
    }

    public void LaunchMultiball()
    {
        //Launch 3 balls
        for ( int i = 0; i < 4; i++ )
        {
            GameObject bally = Instantiate(Ball, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            bally.transform.localScale = new Vector3(0.1f, 0.1f, 0f);
            bally.transform.GetComponent<Rigidbody2D>().AddForce(transform.up * Random.Range(-3000f, 3000f));
            bally.transform.GetComponent<Rigidbody2D>().AddForce(transform.right * Random.Range(-3000f, 3000f));
        }
        Audio.Play();
        ScoreKeeper.GetComponent<ScoreScript>().AddToScore(20);
    }
}