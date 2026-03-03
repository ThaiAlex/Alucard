using UnityEngine;
using System.Collections;

public class HealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public void HurtPlayer(int damageToGive)
    {
        currentHealth -= damageToGive;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}