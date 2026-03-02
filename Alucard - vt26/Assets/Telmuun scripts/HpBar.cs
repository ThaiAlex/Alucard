using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //behöver detta för slider
using TMPro;

//Telmuun

public class HpBar : MonoBehaviour
{
    public Slider healthBarSlider;
    public TextMeshProUGUI healthBarValueText; // texten som säger 100/100
    

    public int maxHealth;   //max hp
    public static float currHealth;  // concurenta hp

    private void Start()
    {

        currHealth = maxHealth;  // sätter den concurenta hp till max




    }

    private void Update()
    {
        //set the health bar text
        healthBarValueText.text = currHealth.ToString() + "/" + maxHealth.ToString(); 

        //set the slider values
        healthBarSlider.value = currHealth;
        healthBarSlider.maxValue = maxHealth;

        if (Input.GetKeyDown(KeyCode.G))
        {
            currHealth -= 10;
        }

        

    }












}