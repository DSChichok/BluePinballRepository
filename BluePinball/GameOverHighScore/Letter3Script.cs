using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter3Script : MonoBehaviour
{
    //Legend
    //  0  1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36
    //  A  B  C  D  E  F  G  H  I  J  K  L  M  N  O  P  Q  R  S  T  U  V  W  X  Y  Z  0  1  2  3  4  5  6  7  8  9  _

    public Animator anim;
    public int Position;
    public bool AllowPress;

    // Use this for initialization
    void Start()
    {
        Position = 0;
        AllowPress = true;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("Pos", Position);
    }

    public void ButtonUp()
    {
        if (AllowPress)
        {
            Position++;
            if (Position > 36)
            {
                Position = 0;
            }
        }
    }

    public void ButtonDown()
    {
        if (AllowPress)
        {
            Position--;
            if (Position < 0)
            {
                Position = 36;
            }
        }
    }
}
