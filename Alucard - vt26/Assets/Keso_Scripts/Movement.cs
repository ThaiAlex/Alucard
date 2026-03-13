using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb; //Rigidbody2D
    [SerializeField, Range(1, 20)] public float moveSpeed; // Hur snabbt v�r karakt�r f�r r�ra sig
    public float jumpForce = 5f; // Vilken force hopp knappen kan g�ra
    public Transform groundCheck; // Kolla om spelaren har r�rt vid marken
    public float groundCheckRadius = 0.5f; // Inom vilken radie kan vi r�ra marken
    public bool isGrounded = false; // Om vi �r p� marken eller inte
    public LayerMask groundLayer; // Vilket lager har marken
    float mx;
    public Animator animator;
    public float walkSoundDelay = 0.4f;
    private float walkTimer = 0f;


    public float dashDistance = 10f;
    public bool isDashing = false;
    public bool isJumping = false;
    public bool canDash = true;
    private float cooldown = 2f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

 

    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); // Kolla om spelaren �r p� marken

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isDashing) // Om vi tycker p� space, s� l�t spelaren hoppa
        {
            rb.AddForce(transform.up * jumpForce);
            isJumping = true;
            isGrounded = false;
            SoundManager.Instance.PlaySound3D("Jump", transform.position);
        }
       
        


        
        bool isWalking = false;

        if (!isDashing)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector2.left * (Time.deltaTime * moveSpeed));
                transform.localScale = new Vector3(-2.2f, 2.2f, 1f);
                isWalking = true;
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector2.right * (Time.deltaTime * moveSpeed));
                transform.localScale = new Vector3(2.2f, 2.2f, 1f);
                isWalking = true;
            }

            if (isWalking)
            {
                walkTimer -= Time.deltaTime;

                if (walkTimer <= 0f)
                {
                    SoundManager.Instance.PlaySound3D("Walk", transform.position);
                    walkTimer = walkSoundDelay;
                }
            }
            else
            {
                walkTimer = 0f;
            }
        }

        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isDashing", isDashing);
        animator.SetBool("isJumping", isJumping);


        if (canDash && Input.GetKeyDown(KeyCode.LeftShift) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            StartCoroutine(Dash(1f));
            SoundManager.Instance.PlaySound3D("Dash", transform.position);
        }
        if (canDash && Input.GetKeyDown(KeyCode.LeftShift) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
        {
            StartCoroutine(Dash(-1f));
            SoundManager.Instance.PlaySound3D("Dash", transform.position);
        }

        float speed = Mathf.Abs(Input.GetAxisRaw("Horizontal"));

       /* animator.SetFloat("Speed", moveSpeed);
        animator.SetBool("Grounded", isGrounded);
        animator.SetBool("Dash", isDashing);
        animator.SetFloat("VerticalVelocity", rb.linearVelocity.y);*/

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        isJumping = false;

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

        if (collision.tag == ("Teleporter"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.tag == ("Reciever"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }


    IEnumerator Dash(float direction)
    {
        canDash = false;
        isDashing = true;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        float gravity = rb.gravityScale;
        rb.gravityScale = 0f;
        yield return new WaitForSeconds(0.3f);
        isDashing = false;
        rb.gravityScale = gravity;
        yield return new WaitForSeconds(cooldown);
        canDash = true;

    }


}
