using UnityEngine;

public class EnemyFollowerPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private LayerMask visionLayers; // layers the raycast can hit

    private GameObject player;
    private bool HasLineOfSight = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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

    private void FixedUpdate()
    {
        Vector2 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;

        RaycastHit2D ray = Physics2D.Raycast(
            transform.position,
            direction,
            distance,
            visionLayers
        );

        if (ray.collider != null)
        {
            HasLineOfSight = ray.collider.CompareTag("Player");

            if (HasLineOfSight)
            {
                Debug.DrawRay(transform.position, direction, Color.green);
                GetComponent<Enemy_Patrol>().enabled = false;
            }
            else
            {
                Debug.DrawRay(transform.position, direction, Color.red);
                GetComponent<Enemy_Patrol>().enabled = true;
            }
        }
    }
}