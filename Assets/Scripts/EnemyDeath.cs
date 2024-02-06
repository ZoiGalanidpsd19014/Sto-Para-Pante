using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public Animator animator;
    bool isDead = true;
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Enemy")
        {
            Debug.Log("Enemy died");
            animator.SetBool("isDying", isDead);
            Destroy(collision.gameObject);
            GameManager.instance.IncreaseScore(10);
        }

    }
}
