using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Blood_Gauge : MonoBehaviour
{
    public int maxBlood;
    public int currentBlood;
    public 
=======

public class Blood_Gauge : MonoBehaviour
{
    public int maxBlood = 20;
    public int currentBlood = 0;
    public float boostSpeed = 8f;
>>>>>>> Stashed changes


    public void Start()
    {
<<<<<<< Updated upstream
        Blood.maxValue = maxEXP;
        expSlider.value = currentEXP;
    }

    public void GainEXP(int amount)
    {
        currentEXP += amount;

        if (currentEXP > maxEXP)
            currentEXP = maxEXP;

        expSlider.value = currentEXP;
    }

=======
        FindFirstObjectByType<Movement>();
    }

    public void GainBlood(int amount)
    {
        currentBlood += amount;

        if(currentBlood > maxBlood)
        {
            currentBlood = maxBlood;
            
        }

    }



>>>>>>> Stashed changes
}
