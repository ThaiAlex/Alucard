using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    [Header("Attack Settings")]
    public Transform attackOrigin;
    public float attackRadius = 1f;
    public LayerMask enemyMask;
    public int attackDamage = 25;

    [Header("Cooldown")]
    public float cooldownTime = 0.5f;
    private float cooldownTimer;

    [Header("Animation")]
    public Animator animator;

    private void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            return;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Attack();
        }
    }

    private void Attack()
    {
        animator?.SetTrigger("Melee");

        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(
            attackOrigin.position,
            attackRadius,
            enemyMask
        );

        foreach (Collider2D enemy in enemiesInRange)
        {
            HealthManager health = enemy.GetComponent<HealthManager>();
           
            
        }

        cooldownTimer = cooldownTime;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackOrigin == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackOrigin.position, attackRadius);
    }
}