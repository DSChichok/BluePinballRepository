using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearScript : MonoBehaviour
{
    // Use this for initialization
    public void StartFollowing(Vector2 ThisTarget)
    {
        transform.position = new Vector2(ThisTarget.x - 1f, ThisTarget.y);
        StartCoroutine(StartDecay());
    }

    IEnumerator StartDecay()
    {
        //StartDecay
        yield return new WaitForSeconds(1f);

        //Destroy Rock
        Destroy(gameObject);
    }
}