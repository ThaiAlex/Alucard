using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Blood_Gauge : MonoBehaviour
{
    public int maxBlood = 20;
    public int currentBlood = 0;
    public float boostSpeed = 8f;

    public void Start()
    {
        FindFirstObjectByType<Movement>();
    }

    public void GainBlood(int amount)
    {
        currentBlood += amount;

        if (currentBlood > maxBlood)
        {
            currentBlood = maxBlood;
        }
    }
}