using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 400;
    public int currentHealth;
    public Vector3 respawnPoint;

    void Start()
    {
        currentHealth = maxHealth;
        respawnPoint = transform.position; // Set respawn point at the start
    }

    public void TakeDamage(int damage, Vector2 knockbackDirection)
    {
        currentHealth -= damage;
        Debug.Log("player took damage");
        if (currentHealth <= 0)
        {
            
            Die();
        }
        // Apply knockback here using the knockbackDirection
        // ...

        // You can reset the position to the respawn point when needed
        // transform.position = respawnPoint;
    }

    void Die()
    {
        Debug.Log("Player died");
        transform.position = respawnPoint;
    }
}
