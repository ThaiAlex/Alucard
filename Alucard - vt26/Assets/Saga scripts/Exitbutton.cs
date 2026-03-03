using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exitbutton : MonoBehaviour
{
    public GameObject ThingIWantToHide; // panel
    public void onClick() //när man klickar knappen
    {
        ThingIWantToHide.SetActive(false); //då tar man bort panelen 
    }
}
//Saga