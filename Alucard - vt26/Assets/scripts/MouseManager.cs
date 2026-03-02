using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public static MouseManager instance;

    public Items currentlyHeldItems;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateHeldItems(UiSlotHandler currentSlot)
    {
        Items currentActiveItems = currentSlot.item;

        if (currentlyHeldItems != null && currentActiveItems != null && currentlyHeldItems.itemID == currentActiveItems.itemID)
        {
            currentSlot.inventoryManager.StackInInventory(currentSlot, currentlyHeldItems);

            currentlyHeldItems = null;
            return;
        }

        if(currentSlot.item != null)
        {
            currentSlot.inventoryManager.ClearItemSlot(currentSlot);
        }

        if(currentlyHeldItems != null)
        {
            currentSlot.inventoryManager.PlaceInInventory(currentSlot, currentlyHeldItems);
        }

        currentlyHeldItems = currentActiveItems;
    }

    public void PickupFromStack(UiSlotHandler currentSlot)
    {
        if(currentlyHeldItems != null && currentlyHeldItems.itemID != currentSlot.item.itemID)
        {
            return;
        }

        if(currentlyHeldItems == null)
        {
            currentlyHeldItems = currentSlot.item.Clone();

            currentlyHeldItems.itemCount = 0;
        }

        currentlyHeldItems.itemCount++;

        currentSlot.item.itemCount--;

        currentSlot.itemsCountText.text = currentSlot.item.itemCount.ToString();

        if(currentSlot.item.itemCount <= 0)
        {
            currentSlot.inventoryManager.ClearItemSlot(currentSlot);
        }
    }
}
