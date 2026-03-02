using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HudBar : MonoBehaviour
{

    //ANVÄNDS INTE!!
    // Start is called before the first frame update
     public float health,maxHealth,Hwidth,Hheight;

     public float stamina, maxStamina, Swidth, Sheight;

    [SerializeField] RectTransform StaminaBar;
    [SerializeField] RectTransform HealthBar;

    public void SetHealthMax(float max)
    {
        max = maxStamina;
    }

    public void SetStaminaMax(float max)
    {
        max = maxHealth;
    }

    public void SetHealth(float hp)
    {
        health = hp;

        float newWidth = (health / maxHealth) * Hwidth;

        HealthBar.sizeDelta = new Vector2(newWidth, Hheight);
    }

    public void SetStamina(float sta)
    {
        stamina = sta;

        float newWidth = (stamina / maxStamina) * Swidth;

        StaminaBar.sizeDelta = new Vector2(newWidth, Sheight);
    }


}
