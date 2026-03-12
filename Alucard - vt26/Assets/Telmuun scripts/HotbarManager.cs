using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HotbarManager : MonoBehaviour
{
    public Item[] hotbar = new Item[9];
    public Image[] slotImages;

    int selectedSlot = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectSlot(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SelectSlot(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SelectSlot(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) SelectSlot(3);
        if (Input.GetKeyDown(KeyCode.Alpha5)) SelectSlot(4);
        if (Input.GetKeyDown(KeyCode.Alpha6)) SelectSlot(5);
        if (Input.GetKeyDown(KeyCode.Alpha7)) SelectSlot(6);
        if (Input.GetKeyDown(KeyCode.Alpha8)) SelectSlot(7);
        if (Input.GetKeyDown(KeyCode.Alpha9)) SelectSlot(8);

        if (Input.GetMouseButtonDown(0))
        {
            UseItem();
        }
    }

    public void AddItem(Item item)
    {
        for (int i = 0; i < hotbar.Length; i++)
        {
            if (hotbar[i] == null)
            {
                hotbar[i] = item;
                slotImages[i].sprite = item.icon;
                return;
            }
        }
    }

    void SelectSlot(int slot)
    {
        selectedSlot = slot;
    }

    void UseItem()
    {
        if (hotbar[selectedSlot] != null)
        {
            hotbar[selectedSlot].Use();
        }
    }
}