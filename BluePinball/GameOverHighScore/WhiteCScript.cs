using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCScript : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip AudioClip_Bling;
    SpriteRenderer spRend;
    Color col;
    bool Decend = false;

	// Use this for initialization
	void Start ()
    {
        Audio.loop = false;
        Audio.clip = AudioClip_Bling;
        Decend = false;
        spRend = transform.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Decend)
        {
            col = spRend.color;
            col.a -= .02f;
            if (col.a < .10f)
            {
                col.a = 0;
                Decend = false;
            }
            spRend.color = col;
        }
	}

    public void MakeWhiteBaby()
    {
        Audio.Play();
        col = spRend.color;
        col.a = 1f;
        spRend.color = col;
        Decend = true;
    }
}
