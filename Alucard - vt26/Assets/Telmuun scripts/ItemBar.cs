using UnityEngine;
using UnityEngine.UI;

public class ItemBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxItems(int items)
    {
        slider.maxValue = items;
        slider.value = 0;
        //items have a max value, cannot exceed a certain number

    }

    public void SetItems(int items)
    {
        slider.value = items;
        //items 
    }
}