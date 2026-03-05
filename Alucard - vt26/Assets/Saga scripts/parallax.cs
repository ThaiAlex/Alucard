using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    private float length, startpos; // length finns
    public GameObject cam; //kamera finns
    public float parallaxEffect; // parallax effekt finns

    void Start() // N�r spelet startar
    {
        startpos = transform.position.x; //kamerans startposition
        length = GetComponent<SpriteRenderer>().bounds.size.x; // l�ngd p� hur l�ngt bilderna renderas
    }

    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));  // 
        float dist = (cam.transform.position.x * parallaxEffect); //

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z); //

        if (temp > startpos + length) startpos += length; //
        else if (temp < startpos - length) startpos -= length; // 
    }
}
// Saga