using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AttackArea : MonoBehaviour
{

    public int damage = 3;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<EnemeyHealthManager>() != null)
        {
            EnemeyHealthManager health = collider.GetComponent<EnemeyHealthManager>();
            health.Damage(damage);
        }
        
    }

}
