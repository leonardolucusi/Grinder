using UnityEngine;

public class EnemyDetectAndMovement : MonoBehaviour
{
    public float detectionRadius = 5f;
    public LayerMask playerLayer;
    public float moveSpeed = 3f;
    public Transform player;
    public Vector3[] patrolPoints;
    private int currentPatrolIndex = 0;
    void Update()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, detectionRadius, playerLayer);

        if (playerCollider != null)
        {
            FollowPlayer();
        }
        else Patrol();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    void FollowPlayer()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0)
        {
            Debug.LogError("No patrol points assigned to the enemy.");
            return;
        }

        Vector3 targetPosition = patrolPoints[currentPatrolIndex];
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetPosition) < 0.2f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }
}
