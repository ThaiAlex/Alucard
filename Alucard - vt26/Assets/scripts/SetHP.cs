using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SetHP : MonoBehaviour
{
    [SerializeField] Slider slider;
    public static float HpBar{ get; private set; }=0;
    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    private void Update()
    {
        slider.value = HpBar;
    }
    public static void HEALTHSET(float hp)
    {
        HpBar = hp;
    }

}
