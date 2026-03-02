using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeinScreen : MonoBehaviour
{
    public GameObject fadeinscreen;
    void Start()
    {
        fadeinscreen.SetActive(false);
    }

    void Update()
    {
        StartCoroutine(Fade());
    }
    
    IEnumerator Fade()
    {
        
        fadeinscreen.SetActive(true);

        yield return new WaitForSeconds(1);

        fadeinscreen.SetActive(false);

    }
}
