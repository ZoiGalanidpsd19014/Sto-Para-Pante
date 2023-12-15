using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacking : MonoBehaviour 
{
    public float limit = 4;
    public float speed = 3;
    public Transform player;
    // Start is called before the first frame update
  
    // Update is called once per frame
    enum State { patrol, attack}
    State myState = State.patrol;
    void Update()
    {   
        switch (myState)
        {
            case State.patrol:
                transform.Translate(speed * Time.deltaTime, 0 , 0);
                if (transform.position.x > limit && speed > 0)
                {
                    speed = -speed;
                }
                if (transform.position.x < -limit && speed < 0)
                {
                    speed = -speed;
                }
                if (Vector3.Distance(transform.position, player.position) < 20)
                {
                    myState = State.attack;
                }
                break;
        
        
            case State.attack:
                transform.position =
        Vector3.MoveTowards(transform.position,
        player.position, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, player.position) >10 ){
                    myState = State.patrol;
                }
                break;
        }
        
    }
}
