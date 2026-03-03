using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            StartCoroutine(RespawnCoroutine());
        }

    }

    IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
