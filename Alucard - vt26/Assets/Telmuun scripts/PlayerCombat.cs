using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public int attackDamage = 40;
    public float attackrange = 0.5f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
        // public Animator animator;

        

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
            }
        }

        void Attack()
        {
            //animator.SetTrigger("Attack");

            //detect enemies in range of attack 
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(
                attackPoint.position,
                attackrange,
                enemyLayers
            );

            foreach (Collider2D enemy in hitEnemies)
            {
                Enemy enemyScript = enemy.GetComponent<Enemy>();

                if (enemyScript != null)
                {
                    enemyScript.TakeDamage(attackDamage);
                    Debug.Log("Hit enemy " + enemy.name);
            }
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (attackPoint == null)
                return;

            Gizmos.DrawWireSphere(attackPoint.position, attackrange);
        }
    }