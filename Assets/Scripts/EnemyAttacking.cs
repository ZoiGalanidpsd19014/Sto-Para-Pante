using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacking : MonoBehaviour 
{
    //public float limit = 4;
    public float speed;
    public Transform player;
    public Animator animator;
    private Rigidbody2D rb;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;
    public int attackDamage = 40;
    
    public GameObject pointA;
    public GameObject pointB;
    private Transform currentPoint;
    public GameObject Enemy;
    public float KnockbackForce = 250;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentPoint = pointB.transform;
        animator.SetBool("isRunning", true);
    }
    // Update is called once per frame
    enum State { patrol, attack}
    State myState = State.patrol;
    void Update()
    {
        switch (myState)
        {
            case State.patrol:
                Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance( transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
                    transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
                    transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                }
                if (Vector2.Distance(transform.position, player.position) < 20)
                {
                    myState = State.attack;
                }
                break;
        
        
            case State.attack:
                transform.position =
        Vector3.MoveTowards(transform.position,
        player.position, speed * Time.deltaTime);
                //animator.SetTrigger("EnemyAttack");
                Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
                foreach (Collider2D player in hitPlayer)
                {
                    player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
                    
                    Enemy.transform.position += transform.forward * Time.deltaTime * KnockbackForce;                  

                }
                if (Vector2.Distance(transform.position, player.position) >10 ){
                    myState = State.patrol;
                }
                break;
        }


    }
}
