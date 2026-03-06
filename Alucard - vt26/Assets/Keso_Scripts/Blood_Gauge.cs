using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Blood_Gauge : MonoBehaviour
{
    public int maxBlood;
    public int currentBlood;
    public 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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

}
