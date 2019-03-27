using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsShowScript : MonoBehaviour
{
    public Animator anim;

    bool FirstPage = true;
	
	// Update is called once per frame
	void Update ()
    {
        anim.SetBool("Pag", FirstPage);
    }

    public void ChangePage()
    {
        FirstPage = !FirstPage;
    }
}
