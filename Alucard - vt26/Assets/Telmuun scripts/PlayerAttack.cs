using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;

    private bool attacking = false;


    public float timeToAttack = 0.25f;
    public float timer = 0f;


    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if (attacking)
        {

            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }


    }


    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }




}
