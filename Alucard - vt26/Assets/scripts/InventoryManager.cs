using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress; //fick error, fixa snälla

public class InventoryManager : MonoBehaviour
{
    public void StackInInventory(UiSlotHandler currentSlot, Items item)
    {
        currentSlot.item.itemCount += item.itemCount;

        currentSlot.itemsCountText.text = currentSlot.item.itemCount.ToString();
    }

    public void PlaceInInventory(UiSlotHandler currentSlot, Items item)
    {
        currentSlot.item = item;

        currentSlot.icon.sprite = item.itemIcon;

        currentSlot.itemsCountText.text = item.itemCount.ToString();

        currentSlot.icon.gameObject.SetActive(true);
    }
    
    public void ClearItemSlot(UiSlotHandler currentSlot)
    {
        currentSlot.item = null;

        currentSlot.icon.sprite = null;

        currentSlot.itemsCountText.text = string.Empty;

        currentSlot.icon.gameObject.SetActive(false);
    }
}
