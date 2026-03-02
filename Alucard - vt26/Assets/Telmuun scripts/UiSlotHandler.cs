using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UiSlotHandler : MonoBehaviour, IPointerClickHandler
{
    public Items item;

    public Image icon;

    public TextMeshProUGUI itemsCountText;

    public InventoryManager inventoryManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (item == null) { return; }

            MouseManager.instance.PickupFromStack(this);

            return;
        }

        MouseManager.instance.UpdateHeldItems(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (item != null)
        {
            item = item.Clone();

            icon.sprite = item.itemIcon;

            itemsCountText.text = item.itemCount.ToString();
        }
        else
        {
            icon.gameObject.SetActive(false);

            itemsCountText.text = string.Empty;
        }
    }


}
