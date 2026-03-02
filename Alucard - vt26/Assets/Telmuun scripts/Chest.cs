using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Telmuun su24
public class Chest : MonoBehaviour, IInteractable
{
    public bool IsOpened { get; private set; } // om kistan är öppen eller inte

    public string ChestID { get; private set; } // unikt ID för kistan
    public GameObject itemprefab; // föremål som droppas när kistan öppnas
    public Sprite openedsprite; // sprite som visas när kistan är öppen

    // Start körs vid start
    void Start()
    {
        ChestID ??= GlobalHelper.GenerateUniqueID(gameObject); // sätter unikt ID om det saknas
    }

    public bool CanInteract()
    {
        return !IsOpened; // går bara att interagera om den inte är öppen
    }

    public void PickUp()
    {
        if (!CanInteract()) return; // stoppar om kistan redan är öppen
        OpenChest(); // öppnar kistan
    }

    private void OpenChest()
    {
        SetOpened(true); // markerar kistan som öppen

        if (itemprefab)
        {
            GameObject droppedItem = Instantiate(itemprefab, transform.position + Vector3.down, Quaternion.identity); // skapar föremålet under kistan
        }

    }

    public void SetOpened(bool opened)
    {
        if (IsOpened = opened) // byter sprite när den öppnas
        {
            GetComponent<SpriteRenderer>().sprite = openedsprite;
        }

    }

    public void Interact()
    {
        throw new System.NotImplementedException(); // måste finnas för IInteractable, men är inte implementerad än
    }
}
