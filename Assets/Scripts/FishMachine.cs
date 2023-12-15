using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMachine : MonoBehaviour
{
    public float speed = 5;
    public float limit = 4;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed, 0);
        if (transform.position.y >limit && speed>0)
        {
            speed = -speed;
        }
        if (transform.position.y < limit && speed < 0)
        {
            speed = -speed;
        }
    }
}
