using UnityEngine;

public class PickupItem : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HotbarManager hotbar = other.GetComponent<HotbarManager>();

            if (hotbar != null)
            {
                hotbar.AddItem(GetComponent<Item>());
                gameObject.SetActive(false);
            }
        }
    }
}