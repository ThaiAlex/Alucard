using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    //Edgar Åberg,Su24
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Ta sönder pilen om den rör allt förutom enemys
        if (collision.gameObject.CompareTag("Enemy")==false) Destroy(gameObject);
    }
}
