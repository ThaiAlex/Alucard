using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class enemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animation anim;
    private Transform currentpoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentpoint.position - transform.position;
        if(currentpoint == pointB.transform)
        {

        }
    }
}
