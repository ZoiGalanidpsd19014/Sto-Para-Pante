using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour {
    public EnemyBehavior enemy;

    void OnTriggerEnter2D(Collider2D collision) {
        enemy.moving = true; 
    }
}
