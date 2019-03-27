using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncherScript : MonoBehaviour
{
    public GameObject BallDetect;
    public GameObject Ball;

    float LowRangeForce;
    float HighRangeForce;

    // Use this for initialization
    void Start()
    {
        LowRangeForce = 500f;
        HighRangeForce = 1000f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LaunchBall()
    {
        GameObject bally = Instantiate(Ball, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        bally.transform.localScale = new Vector3(0.1f, 0.1f, 0f);
        bally.transform.GetComponent<Rigidbody2D>().AddForce(transform.up * Random.Range(LowRangeForce, HighRangeForce));
        bally.transform.GetComponent<Rigidbody2D>().AddForce(-transform.right * HighRangeForce);

        foreach (GameObject m in GameObject.FindGameObjectsWithTag("Minion"))
        {
            if (m.transform.name.Equals("Minion2Special(Clone)"))
            {
                m.GetComponent<Minion2Script>().Follow = true;
            }
            else
            {
                m.GetComponent<MinionScript>().Follow = true;
            }
            SetBossToTrue();
        }

        //Now check for balls
        BallDetect.GetComponent<BallDetectorScript>().StartCheckingForBalls = true;
    }

    void SetBossToTrue()
    {
        foreach (GameObject m in GameObject.FindGameObjectsWithTag("Boss"))
        {
            if (m.transform.name.Equals("Boss02(Clone)"))
            {
                m.GetComponent<Boss2Script>().Follow = true;
            }
        }
    }
}
