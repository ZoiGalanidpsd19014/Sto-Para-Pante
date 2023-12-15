using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioControl : MonoBehaviour {
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float speed = 10;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (GameManager.instance.myState != GameManager.State.playing) return;
        Vector2 v = rb.velocity;
        v.x = Input.GetAxis("Horizontal") * speed;
        rb.velocity = v;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "collectable") {
            Destroy(collision.gameObject);
            GameManager.instance.IncreaseScore(10);
        }
    }
}
