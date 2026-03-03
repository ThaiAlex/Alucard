using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb; //Rigidbody2D
    [SerializeField, Range(1, 20)] public float moveSpeed; // Hur snabbt vår karaktär får röra sig
    public float jumpForce = 5f; // Vilken force hopp knappen kan göra
    public Transform groundCheck; // Kolla om spelaren har rört vid marken
    public float groundCheckRadius = 0.2f; // Inom vilken radie kan vi röra marken
    public bool isGrounded = false; // Om vi är på marken eller inte
    public LayerMask groundLayer; // Vilket lager har marken

    

    public bool canDash = true;
    private bool isDashing;
    public float power = 10f;
    private float cooldown = 2f;
    private float time = 0.3f;


    public bool isFacingRight = false; //Player Sprite Flip


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); // Kolla om spelaren är på marken

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isDashing) // Om vi tycker på space, så låt spelaren hoppa
        {
            rb.AddForce(transform.up * jumpForce);
        }

        if (!isDashing)
        {
            if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
            {
            transform.Translate(Vector2.left * (Time.deltaTime * moveSpeed));
            }

            if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
            {
            transform.Translate(Vector2.right * (Time.deltaTime * moveSpeed));
            }

        }


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());
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


    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = false;
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(transform.localScale.x * power, 0);
        yield return new WaitForSeconds(time);
        isDashing = false;
        rb.gravityScale = 3;
        yield return new WaitForSeconds(cooldown);
        canDash = true;

    }


}
