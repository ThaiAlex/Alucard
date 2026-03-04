using System;
using UnityEngine;

public class EnemeyHealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public void HurtEnemy(int damageToGive)
    {
        currentHealth -= damageToGive;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    internal void Damage(int damage)
    {
        throw new NotImplementedException();
    }
}