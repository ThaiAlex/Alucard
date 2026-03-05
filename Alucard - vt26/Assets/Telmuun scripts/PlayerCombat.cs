using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackrange = 0.5f;
    public LayerMask enemyLayers;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }

    }

    void Attack()
    {

        animator.SetTrigger("Attack");

        // detect enemies in range of attack 
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint. position, attackrange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
        }


    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackrange);
    }



}
