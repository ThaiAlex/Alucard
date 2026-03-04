using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float knockbackForce = 5f;
    private Rigidbody2D rb;

    private void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }


    public void HurtPlayer(int damageToGive, Transform damageSource)
    {
        currentHealth -= damageToGive;
        Vector2 knockbackDirection = new Vector2(transform.position.y > damageSource.position.y ? 10f : -10f, 0.5f).normalized;
        rb.linearVelocity = Vector2.zero; // Optional: reset velocity first
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

        if (currentHealth <= 0)
        {
            StartCoroutine(RespawnCoroutine());
        }

    }

    IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
