using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Kolla om det är spelaren som träffar
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>(); // Hämta spelarens inventory

            if (inventory != null)// Säkerställ att inventory finns
            {
                inventory.AddItem(value);// Lägg till itemets värde i inventory

            }

            Destroy(gameObject); // ta bort itemet från scenen
        }
    }
}