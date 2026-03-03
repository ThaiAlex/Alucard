using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;


    private void Start()
    {
        currentHealth = maxHealth;
    }


    public void HurtPlayer(int damageToGive)
    {
        currentHealth -= damageToGive;


        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

    }


}
