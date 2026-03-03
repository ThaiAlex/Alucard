using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; //Så vi kan reloada scenen om vi dör

public class HealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    
    public void HurtPlayer(int damageToGive)
    {
        currentHealth -= damageToGive;
        if (currentHealth <= 0)
        {
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    
}