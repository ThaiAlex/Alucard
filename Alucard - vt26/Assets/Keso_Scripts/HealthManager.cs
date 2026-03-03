using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public GameObject bloodEffect;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    public void TakeDamage(int damage, Vector2 origin)
    {
        currentHealth -= damage;

        // Blood Particle example
        Instantiate(bloodEffect, transform.position, Quaternion.identity);

        // Camera shake code example
        //CameraShake.instance.Shake();

        // Knockback code example
        

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        healthBar.SetCurrentHealth(currentHealth);
    }
}
