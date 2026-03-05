using UnityEngine;

public class OpenUsingEsc : MonoBehaviour
{
    public GameObject ShowObject; // panelen

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            print("Esc key is held down");

            ShowObject.SetActive(true); //då kommer menyn fram 
        }

    }
}
