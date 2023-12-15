using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public float timeout = 5;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

      void Update()
        {
            timer += Time.deltaTime;
            if (timer > timeout)
            {

                Destroy(gameObject);
            }
        }

    
}
