using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightFlipperScript : MonoBehaviour
{
    public bool PressDown;

    HingeJoint2D hinge;
    JointMotor2D motor;
    bool Free;
    float FlipperSpeed;

    // Use this for initialization
    void Start()
    {
        FlipperSpeed = 3000f;
        hinge = GetComponent<HingeJoint2D>();
        motor = hinge.motor;
        motor.motorSpeed = 3000f;
        motor.maxMotorTorque = FlipperSpeed;
        hinge.motor = motor;
        Free = true;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Free)
        {
            if (PressDown)
            {
                //Debug.Log("DownRight");
                motor = hinge.motor;
                motor.motorSpeed = FlipperSpeed;
                hinge.motor = motor;
            }
            else
            {
                //Debug.Log("UpRight");
                motor = hinge.motor;
                motor.motorSpeed = -FlipperSpeed;
                hinge.motor = motor;
            }
        }
    }


}
