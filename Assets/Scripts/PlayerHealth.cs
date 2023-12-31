using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public Animator animator;
    bool isDead = true;
    public Vector3 respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    
    public void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;


        }


        if (currentHealth <= 0)
        {
            Die();
            Live();
        }


    }
    void Die()
    {
            Debug.Log("Player died");
            
            animator.SetBool("isDying", isDead);
        
            
    }

    void Live()
    {
        animator.SetBool("isLiving", !isDead);
        transform.position = respawnPoint;
        
    }
}
