using UnityEngine;

public class Hotbar : MonoBehaviour
{
    public GameObject[] items = new GameObject[9]; // slots 1–9
    private int currentSlot = -1;

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

    void SelectSlot(int slot)
    {
        if (slot >= items.Length) return;

        currentSlot = slot;
        Debug.Log("Selected slot: " + (slot + 1));
    }

    void UseItem()
    {
        if (currentSlot == -1) return;

        GameObject item = items[currentSlot];

        if (item != null)
        {
            item.SendMessage("Use", SendMessageOptions.DontRequireReceiver);
        }
    }
}