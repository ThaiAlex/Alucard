using UnityEngine;
using UnityEngine.UI; // behövs för att prata med Slider

public class PlayerStats : MonoBehaviour
{
    [Header("Health (liv)")]
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private float currentHealth = 10f;

    [Header("Stamina (uthållighet)")]
    [SerializeField] private float maxStamina = 100f;
    [SerializeField] private float currentStamina = 100f;
    [SerializeField] private float staminaRegenRate = 10f; // hur snabbt stamina fylls på

    [Header("UI (kopplingar till HUD)")]
    [SerializeField] private Slider healthBar;   // din healthbar i scenen
    [SerializeField] private Slider staminaBar;  // din staminabar i scenen

    private void Start()
    {
        // Sätter upp sliders när spelet startar
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }

        if (staminaBar != null)
        {
            staminaBar.maxValue = maxStamina;
            staminaBar.value = currentStamina;
        }
    }

    private void Update()
    {
        // Återställ stamina långsamt
        if (currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        }

        // Uppdatera sliders
        if (healthBar != null)
            healthBar.value = currentHealth;

        if (staminaBar != null)
            staminaBar.value = currentStamina;
    }

    // Kallas när spelaren tar skada
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
            Die();
    }

    // Kallas när spelaren använder stamina
    public bool UseStamina(float amount)
    {
        if (currentStamina >= amount)
        {
            currentStamina -= amount;
            return true; // användningen lyckades
        }
        else
        {
            Debug.Log("För lite stamina!");
            return false; // inte tillräckligt med stamina
        }
    }

    private void Die()
    {
        Debug.Log("Spelaren dog!");
        Destroy(gameObject); // eller valfri dödhantering
    }
}
