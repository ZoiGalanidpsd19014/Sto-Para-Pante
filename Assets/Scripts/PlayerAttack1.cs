using System.Collections;
using UnityEngine;

public class PlayerAttack1 : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;
    public float attackCooldownMouse1 = 0.25f;
    public float attackCooldownMouse2 = 0.57f;

    private bool canAttack1 = true;
    private bool canAttack2 = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canAttack1)
        {
            StartCoroutine(AttackWithCooldown(1, attackCooldownMouse1));
        }
        if (Input.GetMouseButtonDown(1) && canAttack2)
        {
            StartCoroutine(AttackWithCooldown(2, attackCooldownMouse2));
        }
    }

    void Attack(int attackType)
    {
        if (attackType == 1)
        {
            animator.SetTrigger("Attack");
        }
        else if (attackType == 2)
        {
            animator.SetTrigger("Attack2");
        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    IEnumerator AttackWithCooldown(int attackType, float cooldown)
    {
        if (attackType == 1)
        {
            canAttack1 = false;
        }
        else if (attackType == 2)
        {
            canAttack2 = false;
        }

        Attack(attackType);

        yield return new WaitForSeconds(cooldown);

        if (attackType == 1)
        {
            canAttack1 = true;
        }
        else if (attackType == 2)
        {
            canAttack2 = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}