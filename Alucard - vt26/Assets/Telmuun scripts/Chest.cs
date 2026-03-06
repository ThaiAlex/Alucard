using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Telmuun su24
public class Chest : MonoBehaviour, IInteractable
{
    public bool IsOpened { get; private set; } // om kistan �r �ppen eller inte

    public string ChestID { get; private set; } // unikt ID f�r kistan
    public GameObject itemprefab; // f�rem�l som droppas n�r kistan �ppnas
    public Sprite openedsprite; // sprite som visas n�r kistan �r �ppen

    // Start k�rs vid start
    void Start()
    {
        ChestID ??= GlobalHelper.GenerateUniqueID(gameObject); // s�tter unikt ID om det saknas
    }

    public bool CanInteract()
    {
        return !IsOpened; // g�r bara att interagera om den inte �r �ppen
    }

    public void PickUp()
    {
        if (!CanInteract()) return; // stoppar om kistan redan �r �ppen
        OpenChest(); // �ppnar kistan
    }

    private void OpenChest()
    {
        SetOpened(true); // markerar kistan som �ppen

        if (itemprefab)
        {
            GameObject droppedItem = Instantiate(itemprefab, transform.position + Vector3.down, Quaternion.identity); // skapar f�rem�let under kistan
        }

    }

    public void SetOpened(bool opened)
    {
        if (IsOpened = opened) // byter sprite n�r den �ppnas
        {
            GetComponent<SpriteRenderer>().sprite = openedsprite;
        }

    }

    public void Interact()
    {
        throw new System.NotImplementedException(); // m�ste finnas f�r IInteractable, men �r inte implementerad �n
    }
}
