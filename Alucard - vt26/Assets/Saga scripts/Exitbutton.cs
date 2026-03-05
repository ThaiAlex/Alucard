using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exitbutton : MonoBehaviour
{
    public GameObject ThingIWantToHide; // panel
    public void onClick() //n�r man klickar knappen
    {
        ThingIWantToHide.SetActive(false); //d� tar man bort panelen 
    }
}
//Saga