using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonForOpeningPanel: MonoBehaviour
{
    public GameObject ShowThis; // panel
    public void onClick() //när man klickar knappen
    {
        ShowThis.SetActive(true); //då tar man fram panelen 
    }
}
//Saga