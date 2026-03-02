using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb; //Rigidbody2D
    [SerializeField, Range(1, 20)] public float moveSpeed; // Hur snabbt vår karaktär får röra sig
    [SerializeField, Range(1, 100)] public float sprintSpeed;//Hur snabbt karaktären kan springa
    public float jumpForce = 5f; // Vilken force hopp knappen kan göra
    public Transform groundCheck; // Kolla om spelaren har rört vid marken
    public float groundCheckRadius = 0.2f; // Inom vilken radie kan vi röra marken
    public bool isGrounded = false; // Om vi är på marken eller inte
    public LayerMask groundLayer; // Vilket lager har marken


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); // Kolla om spelaren är på marken

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // Om vi tycker på space, så låt spelaren hoppa
        {
            rb.AddForce(transform.up * jumpForce);
        }

        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            transform.Translate(Vector2.left * (Time.deltaTime * moveSpeed));
        }

        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            transform.Translate(Vector2.right * (Time.deltaTime * moveSpeed));
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = sprintSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed -= 4f;
        }

    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = false;

        print("collision" + collision.gameObject.name);
        if (collision.gameObject.GetComponent<Interactable>() == true)
        {
            collision.gameObject.GetComponent<Interactable>().Interact();

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("trigger" + collision.gameObject.name);
        if (collision.gameObject.GetComponent<Interactable>() == true)
        {
            collision.gameObject.GetComponent<Interactable>().Interact();
        }

    }

}
