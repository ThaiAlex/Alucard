using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private HealthManager healthManager;
    public Slider healthBar;
    private Blood_Gauge bloodManager;
    public Slider bloodBar;

    void Start()
    {
        healthManager = FindFirstObjectByType<HealthManager>();
        bloodManager = FindFirstObjectByType<Blood_Gauge>();
    }

    void Update()
    {
        healthBar.maxValue = healthManager.maxHealth;
        healthBar.value = healthManager.currentHealth;

        bloodBar.maxValue = bloodManager.maxBlood;
        bloodBar.value = bloodManager.currentBlood;
    }
}