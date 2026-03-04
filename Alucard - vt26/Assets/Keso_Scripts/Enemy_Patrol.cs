using System.Collections;
using UnityEngine;

public class Enemy_Patrol : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float leftStopX, rightStopX;
    [SerializeField] private int facingDirection = 1;

    [SerializeField] private float minPauseTime, maxPauseTime;
    [SerializeField] private float minWalkTime, maxWalkTime;

    private float randomTime, timer;
    private bool isWalking = true;
    private bool isFlipping;


    private void Start()
    {
        randomTime = Random.Range(minWalkTime, maxWalkTime);
    }


    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= randomTime)
        {
            StateChange();
        }

        // Flip only when moving and not already flipping
        if (isWalking && !isFlipping && ((facingDirection == 1 && rb.position.x > rightStopX) ||
             (facingDirection == -1 && rb.position.x < leftStopX)))
        {
            StartCoroutine(Flip());
        }
    }

    private void FixedUpdate()
    {
        if (isWalking)
        {
            rb.linearVelocity = Vector2.right * facingDirection * speed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
        // ?? Clamp position within X boundaries every physics update
        float clampedX = Mathf.Clamp(rb.position.x, leftStopX, rightStopX);
        rb.position = new Vector2(clampedX, rb.position.y);
    }

    IEnumerator Flip()
    {
        isFlipping = true;
        transform.Rotate(0, 180, 0);
        facingDirection *= -1;
        yield return new WaitForSeconds(0.5f);
        isFlipping = false;
    }

    void StateChange()
    {
        isWalking = !isWalking;
        randomTime = isWalking ? Random.Range(minWalkTime, maxWalkTime) : Random.Range(minPauseTime, maxPauseTime);
        timer = 0;
    }
}
