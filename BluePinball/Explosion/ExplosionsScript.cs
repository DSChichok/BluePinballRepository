using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionsScript : MonoBehaviour
{
    public GameObject Explosion;

    private bool Explode = false;
    private float x;
    private float y;
    private int Counter = 0;
    private float Timer = .5f;

    public void StartExplosions()
    {
        Explode = true;
        StartCoroutine(StartExplodingg());
    }

    IEnumerator StartExplodingg()
    {
        while (Explode)
        {
            yield return new WaitForSeconds(Timer);
            x = Random.Range(-3f, 3f);
            y = Random.Range(-3f, 3f);
            GameObject m = Instantiate(Explosion, new Vector2(x, y), Quaternion.identity);
            m.transform.localScale = new Vector3(3f, 3f, 3f);

            Counter++;
            if (Counter == 10)
            {
                Timer = .25f;
            }
        }
        
    }

    public void StopExplosions()
    {
        Explode = false;
        Timer = .5f;
        Counter = 0;
    }
}