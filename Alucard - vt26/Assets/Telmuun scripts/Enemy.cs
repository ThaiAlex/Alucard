using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject bloodSplatter;
    public int maxHealth = 100;
    int currentHealth;
    public int bloodSpill = +1;
    private Blood_Gauge Blood_Gauge;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        SoundManager.Instance.PlaySound3D("HurtEnemy", transform.position);
        Instantiate(bloodSplatter, transform.position + new Vector3(0,2,0), Quaternion.identity);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Blood_Gauge player = FindFirstObjectByType<Blood_Gauge>();
        player.GainBlood(bloodSpill);
        Destroy(gameObject);
    }
}
