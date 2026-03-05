using Unity.VisualScripting;
using UnityEngine;

public class OpenUsingEnter : MonoBehaviour
{
    public GameObject ShowObject; // panelen

    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            print("Enter key is held down");

            ShowObject.SetActive(true); //då kommer panelen fram 
        }

    }
}


   

