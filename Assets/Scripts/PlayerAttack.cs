using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int baseAttackDamage1 = 40;
    public int baseAttackDamage2 = 60;
    public float moveSpeed = 12f; // Initial move speed
    private int currentScore = 0;
    private int scoreToIncreaseStats = 4; // Increase stats every 4 points
    private float attack2Cooldown = 0.5f; // Cooldown for Attack2
    private bool isAttack2OnCooldown = false; // Flag to check if Attack2 is on cooldown

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack(baseAttackDamage1);
        }
        if (Input.GetMouseButtonDown(1) && !isAttack2OnCooldown)
        {
            Attack(baseAttackDamage2);
            StartCoroutine(Attack2Cooldown());
        }
    }

    void Attack(int damage)
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
            Debug.Log("Attack damage: " + damage);
            currentScore++;
            UpdateStats();
        }
    }

    IEnumerator Attack2Cooldown()
    {
        isAttack2OnCooldown = true;
        yield return new WaitForSeconds(attack2Cooldown);
        isAttack2OnCooldown = false;
    }

    void UpdateStats()
    {
        if (currentScore >= scoreToIncreaseStats && currentScore % scoreToIncreaseStats == 0)
        {
            baseAttackDamage1 += 15;
            baseAttackDamage2 += 15;

            Debug.Log("Stats increased - Damage: " + baseAttackDamage1 + ", " + baseAttackDamage2 + " at score " + currentScore);
        }
        else
        {
            Debug.Log("UpdateStats not triggered. Score: " + currentScore);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
