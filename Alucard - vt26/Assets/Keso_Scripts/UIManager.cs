using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private HealthManager healthManager;
    public Slider healthBar;
    private Blood_Gauge bloodManager;
<<<<<<< Updated upstream
    public Slider Blood;
    public int currentBlood = 0;
    public int maxBlood = 30;

    void Start()
    {
        healthManager = FindFirstObjectByType<HealthManager>();
        Blood.maxValue = maxBlood;
        Blood_Gauge.value = currentBlood;
=======
    public Slider bloodBar;
    void Start()
    {
        healthManager = FindFirstObjectByType<HealthManager>();
        bloodManager = FindFirstObjectByType<Blood_Gauge>();

>>>>>>> Stashed changes
    }
    void Update()
    {
        healthBar.maxValue = healthManager.maxHealth;
        healthBar.value = healthManager.currentHealth;
<<<<<<< Updated upstream
        Blood.maxValue = bloodManager.maxBlood;
        Blood.value = bloodManager.currentBlood;

=======

        bloodBar.maxValue = bloodManager.maxBlood;
        bloodBar.value = bloodManager.currentBlood;
>>>>>>> Stashed changes
    }
}
