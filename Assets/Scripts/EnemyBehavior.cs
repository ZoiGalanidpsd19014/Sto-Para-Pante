using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    // Start is called before the first frame update
    public bool moving = false;
    Rigidbody2D rb;
    public float speed = -1;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (moving) {
            rb.velocity = new Vector2(speed, 0);
        }
    }
}
