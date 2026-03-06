using UnityEngine;

public class EnemyFollowerPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private LayerMask visionMask; // Only layers that block vision, Wall

    private GameObject player;
    private bool HasLineOfSight = false;
    private Enemy_Patrol patrolScript;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        patrolScript = GetComponent<Enemy_Patrol>();
    }

    void Update()
    {
        if (HasLineOfSight)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.transform.position,
                speed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        Vector2 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;

        // Raycast only hits visionMask (walls)
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            direction,
            distance,
            visionMask
        );

        // If ray hits something, it's a wall cant see player
        if (hit.collider == null)
        {
            HasLineOfSight = true;
            Debug.DrawRay(transform.position, direction, Color.green);
            if (patrolScript != null)
                patrolScript.enabled = false;
        }
        else
        {
            HasLineOfSight = false;
            Debug.DrawRay(transform.position, direction, Color.red);
            if (patrolScript != null)
                patrolScript.enabled = true;
        }
    }
}