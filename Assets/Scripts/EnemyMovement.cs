using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float patrolSpeed = 5f;
    public float chaseSpeed = 6.5f;
    public float patrolDistance = 4f;
    public float chaseDistance = 8f;

    private Transform player;
    private Vector3 initialPosition;
    private bool isChasing = false;
    private bool hasChased = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        initialPosition = transform.position;
    }

    void Update()
    {
        if (player != null)
        {
            if (isChasing)
            {
                ChasePlayer();
            }
            else
            {
                Patrol();
                if (!hasChased && Vector3.Distance(transform.position, player.position) <= chaseDistance)
                {
                    isChasing = true;
                    hasChased = true;
                }
            }
        }
        else
        {
            Debug.LogWarning("Player not found.");
        }
    }

    void Patrol()
    {
        float movement = Mathf.PingPong(Time.time * patrolSpeed, patrolDistance * 2) - patrolDistance;
        transform.position = new Vector3(initialPosition.x + movement, transform.position.y, transform.position.z);
    }

    void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);

        // Additional logic for attacking or any other behavior during chase
    }
}
