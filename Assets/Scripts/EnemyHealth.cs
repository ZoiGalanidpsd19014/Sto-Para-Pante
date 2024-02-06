using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;
    bool isDead;
    public Animator animator;




    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        

    }


    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            animator.SetBool("damage", isDead);

        }
        if (currentHealth <= 0)
        {
            animator.SetBool("isDying", isDead);
            Destroy(gameObject);
            GameManager.instance.IncreaseScore(10);
            Debug.Log("Enemy died");
        }
    }
    

}
