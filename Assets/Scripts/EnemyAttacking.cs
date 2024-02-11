using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask playerLayers;

    public float knockbackForce = 10f;
    public int attackDamage = 40;

    void Update()
    {
        PerformAttack();
    }

    void PerformAttack()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        foreach (Collider2D playerCollider in hitPlayers)
        {
            PlayerHealth playerHealth = playerCollider.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                Vector2 knockbackDirection = CalculateKnockbackDirection(playerCollider.transform.position);
                playerHealth.TakeDamage(attackDamage, knockbackDirection);
            }
        }
    }

    Vector2 CalculateKnockbackDirection(Vector2 playerPosition)
    {
        return (playerPosition - (Vector2)transform.position).normalized;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
