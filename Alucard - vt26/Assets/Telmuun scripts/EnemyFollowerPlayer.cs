using UnityEngine;

public class EnemyFollowerPlayer : MonoBehaviour
{

    [SerializeField] private float speed = 1.5f;
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
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        if(ray.collider != null)
        {
            HasLineOfSight = ray.collider.CompareTag("Player");
            if (HasLineOfSight)
            {
                
                Vector3 direction = player.transform.position - transform.position;
                Debug.DrawRay(transform.position, direction, Color.green);
            }
            else
            {

                Vector3 direction = player.transform.position - transform.position;
                Debug.DrawRay(transform.position, direction, Color.red);

            }



        }

    }


}
