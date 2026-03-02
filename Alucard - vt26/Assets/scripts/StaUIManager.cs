using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StaUIManager : MonoBehaviour
{
    public Slider healthBarSlider;
    public TextMeshProUGUI healthBarValueText; // texten som s�ger 100/100
    private float hpbar;

    // Start is called before the first frame update
    void Start()
    {
        //hpbar = FindObjectOfType<HpBar>();
    }

    // Update is called once per frame
    void Update()
    {
        //healthBarSlider.maxValue = hpbar.maxHealth;
        //healthBarSlider.value = HpBar.currHealth;
    }

    // Edgar hj�lp mig pls
}
