using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerScript : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip AudioClip_GunCock;
    public AudioClip AudioClip_Woosh;
    public bool CheckCock;
    public GameObject Master;


    bool MouseDrag;
    bool GunCocked;
    bool Launch;
    bool Retract;
    Vector3 mousePosition;
    Vector3 objectPosition;
    float SpeedOfClimb;

    // Use this for initialization
    void Start ()
    {
        //Never let audio announcer clips repeat
        Audio.loop = false;
        SpeedOfClimb = 1f;
        Reset();
    }

    public void Reset()
    {
        transform.position = new Vector3(0f, -7f, 100f);
        MouseDrag = false;
        GunCocked = false;
        CheckCock = false;
        Launch = false;
        Retract = false;
    }

    // Update is called once per frame
    void Update ()
    {
        //Start retracting plunger if Gun was cocked and plunger was let go
        if (Retract)
        {
            if (transform.position.y < 3f)
            {
                transform.position = new Vector2(0f, transform.position.y + SpeedOfClimb);
            }
            else
            {
                Retract = false;
                transform.position = new Vector2(0f, 3f);
                if (Launch)
                {
                    Master.GetComponent<MasterBackgroundScript>().TriggerSwitch();
                }
            }
            
        }
        else if (MouseDrag)
        {
            mousePosition = Input.mousePosition;
            objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            if (objectPosition.y < -2f)
            {
                transform.position = new Vector2(0f, -2f);
            }
            else
            {
                transform.position = new Vector2(0f, objectPosition.y);
            }
            

            if (Input.GetMouseButtonUp(0))
            {
                MouseDrag = false;

                //Play a let-go sound here


                //At this point determine if drag was far enough to actually launch the ball
                if (GunCocked)
                {
                    Retract = true;
                    Launch = true;
                    Audio.clip = AudioClip_Woosh;
                    Audio.Play();
                }
                else if (!GunCocked && transform.position.y < 3f)  //plunger wasn't pulled back far enough, return back
                {
                    Retract = true;
                    Audio.clip = AudioClip_Woosh;
                    Audio.Play();
                }
                else  //Player thought it was funny to push the plunger in instead of pulling it
                {
                    transform.position = new Vector2(0f, 3f);
                }
            }
        }

        if (CheckCock)
        {
            if (!GunCocked && transform.position.y < -0.6f)
            {
                GunCocked = true;
                Audio.clip = AudioClip_GunCock;
                Audio.Play();
            }
        }
	}

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseDrag = true;
        }
    }
}
