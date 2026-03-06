using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int currentItems = 0;
    public int maxItems = 10;

    public ItemBar itemBar;

    void Start()
    {
        itemBar.SetMaxItems(maxItems);
    }

    public void AddItem(int amount)
    {
        currentItems += amount;

        if (currentItems > maxItems)
            currentItems = maxItems;

        itemBar.SetItems(currentItems);
    }
}