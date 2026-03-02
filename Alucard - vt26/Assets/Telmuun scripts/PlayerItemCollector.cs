using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
// Telmuun su24
public class PlayerItemCollector : MonoBehaviour
{
    private
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Item item = collision.GetComponent<Item>();
            if (item != null)
            {
                //adda vår item i inventory
            }

        }


    }

}
