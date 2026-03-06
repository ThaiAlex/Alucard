using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private HealthManager healthManager;
    public Slider healthBar;
    private Blood_Gauge bloodManager;
    public Slider Blood;
    public int currentBlood = 0;
    public int maxBlood = 30;

    void Start()
    {
        healthManager = FindFirstObjectByType<HealthManager>();
        Blood.maxValue = maxBlood;
        Blood_Gauge.value = currentBlood;
    }
    void Update()
    {
        healthBar.maxValue = healthManager.maxHealth;
        healthBar.value = healthManager.currentHealth;
        Blood.maxValue = bloodManager.maxBlood;
        Blood.value = bloodManager.currentBlood;

    }
}
