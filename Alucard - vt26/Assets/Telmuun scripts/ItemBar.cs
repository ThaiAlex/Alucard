using UnityEngine;
using UnityEngine.UI;

public class ItemBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxItems(int items)
    {
        slider.maxValue = items;
        slider.value = 0;
    }

    public void SetItems(int items)
    {
        slider.value = items;
    }
}