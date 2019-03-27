using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopScreenScript : MonoBehaviour
{
    public bool Shake;
    public bool BossDown;
    float x;
    float y;
    int Counter;
    public Animator anim;
    int BackgroundCount = 0;

    // Use this for initialization
    void Start ()
    {
        Shake = false;
        Counter = -1;
        BackgroundCount = 0;
        anim.SetInteger("BackgroundSet", BackgroundCount);
    }

    public void ChangeBackground()
    {
        BackgroundCount++;
        if (BackgroundCount > 6)
        {
            BackgroundCount = 0;
        }
        anim.SetInteger("BackgroundSet", BackgroundCount);
    }


    // Update is called once per frame
    void Update ()
    {
        //if (Input.GetKeyDown("f"))
        //{
        //    ChangeBackground();
        //}

        if (Shake)
        {
            y = Random.Range(-.3f, .3f);
            transform.position = new Vector2(transform.position.x, transform.position.y + y);
        }
        if (BossDown)  //Pretty much cutscene signaling boss death
        {
            x = Random.Range(-.3f, .3f);
            y = Random.Range(-.3f, .3f);
            transform.position = new Vector2(transform.position.x + x, transform.position.y + y);
            Counter++;
            if (Counter > 4)  //This is so the screen doesn't go everywhere
            {
                Counter = 0;
                transform.position = new Vector2(0f, 0f);
            }
        }
        else
        {
            if (Counter > -1) //If so this means the screen was shaking from the boss prior
            {
                Counter = -1;
                transform.position = new Vector2(0f, 0f);
            }
        }
	}
}